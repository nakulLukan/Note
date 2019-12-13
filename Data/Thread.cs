using System;
using System.Collections.Generic;

namespace Note.Web.Data
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Comment> Comments { get; set; }
        public List<ThreadTag> Tags { get; set; }

        public Thread()
        {
            Comments = new List<Comment>();
            Tags = new List<ThreadTag>();
        }
    }
}
