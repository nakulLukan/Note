using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Note.Interfaces;
using Note.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Pages
{
    public class HomeBase : ComponentBase
    {
        [Inject]
        IDataService DataService { get; set; }

        [Inject]
        IJSIntrop JSRuntime { get; set; }

        [Inject]
        IQuickNoteModal Modal { get; set; }

        [Parameter]
        public bool HasThreads { get; set; } = false;

        public Thread Note { get; set; } = new Thread();

        protected override async Task OnInitializedAsync()
        {
            var threads = await DataService.GetLastNThreads();
            if (threads.Any())
            {
                HasThreads = true;
            }
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await this.JSRuntime.InitNotePad();
            }
        }

        public void OpenNotePad()
        {
            Modal.ShowModal("create-note-modal");
        }
    }
}
