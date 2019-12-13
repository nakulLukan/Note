using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Interfaces
{
    public interface IQuickNoteModal
    {
        void ShowModal(string modalId);

        void HideModal(string modalId);

        void ClearContent();
    }
}
