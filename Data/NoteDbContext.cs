using Microsoft.EntityFrameworkCore;

namespace Note.Web.Data
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Thread> Threads { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ThreadTag> ThreadTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
