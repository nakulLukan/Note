using Microsoft.EntityFrameworkCore;
using Note.Interfaces;
using Note.Web.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Services
{
    public class DataService : IDataService
    {
        private readonly NoteDbContext _context;
        public DataService(NoteDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get top N recent threads in decreasing order of UpdatedAt property.
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public async Task<List<Thread>> GetLastNThreads(int top = 10)
        {
            return await _context.Threads.OrderByDescending(x=>x.CreatedAt).Include(x=>x.Comments).ToListAsync();
        }

        /// <summary>
        /// Get tag by tag name.
        /// </summary>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public Tag GetTagByName(string tagname)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Name.ToLower() == tagname.ToLower());
            if (tag == null)
            {
                var insertedTag = _context.Tags.Add(new Tag()
                {
                    Name = tagname.ToLower()
                });

                _context.SaveChanges();
                return insertedTag.Entity;
            }

            return tag;
        }

        /// <summary>
        /// Save the intial note with one comment.
        /// </summary>
        /// <param name="comment"></param>
        public void SaveNote(Thread thread)
        {
            _context.Threads.Add(thread);
            _context.SaveChanges();
        }

        public async Task<List<string>> GetSuggestedTags()
        {
            var tags = await _context.ThreadTags.GroupBy(x => new { x.TagId, x.ThreadId })?.OrderByDescending(x => x.Count()).Take(5)?.Select(x => x.Key.TagId).ToListAsync();
            List<string> suggestedTags = new List<string>();
            if (tags.Any())
            {
                suggestedTags.AddRange(await _context.Tags.Where(x => tags.Contains(x.Id)).Select(x => x.Name).ToListAsync());
            }
            if (suggestedTags.Count < 5)
            {
                suggestedTags.AddRange((await _context.Tags.Select(x => x.Name).ToListAsync())?.TakeLast(5) ?? new List<string>());
            }
            return suggestedTags.Distinct().ToList();
        }
    }
}
