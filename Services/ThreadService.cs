using Note.Interfaces;
using Note.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Services
{
    public class ThreadService : IThreadService
    {
        /// <summary>
        /// Fill the dashboard with top N issues. 
        /// </summary>
        /// <returns></returns>
        public List<NoteViewModel> FillDashboardWithThreads()
        {
            return new List<NoteViewModel>();
        }
    }
}
