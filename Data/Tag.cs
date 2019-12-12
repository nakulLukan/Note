using System.Collections.Generic;

namespace Note.Web.Data
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Thread> Threads { get; set; }
    }
}
