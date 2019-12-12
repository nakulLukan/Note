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
            return await _context.Threads.AsNoTracking().ToListAsync();
        }
    }
}
