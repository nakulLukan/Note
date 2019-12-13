using Microsoft.JSInterop;
using Note.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Services
{
    public class QuickNoteModalService : IQuickNoteModal
    {
        IJSRuntime JSRuntime;
        public QuickNoteModalService(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
        }

        public void ClearContent()
        {
            JSRuntime.InvokeVoidAsync("ClearQuickNoteContent");
        }

        public void HideModal(string modalId)
        {
            JSRuntime.InvokeVoidAsync("HideModal", string.Concat("#", modalId));
        }

        public void ShowModal(string modalId)
        {
            JSRuntime.InvokeVoidAsync("ShowModal", string.Concat("#", modalId));
        }
    }
}
