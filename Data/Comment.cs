using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Note.Web.Data
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("Thread")]
        public int ThreadId { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Thread Thread { get; set; }
    }
}
