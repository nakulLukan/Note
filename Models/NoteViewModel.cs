using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Models
{
    public class NoteViewModel
    {
        public string ThreadId { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ContentViewModel> Comments { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}
