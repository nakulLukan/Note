using System.ComponentModel.DataAnnotations.Schema;

namespace Note.Web.Data
{
    public class ThreadTag
    {
        public int Id { get; set; }

        [ForeignKey("Thread")]
        public int ThreadId { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }

        public Thread Thread { get; set; }
        public Tag Tag { get; set; }
    }
}
