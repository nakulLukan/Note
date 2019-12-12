using Note.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Interfaces
{
    public interface IThreadService
    {
        List<NoteViewModel> FillDashboardWithThreads();
    }
}
