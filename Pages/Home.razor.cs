using Microsoft.AspNetCore.Components;
using Note.Interfaces;
using Note.Web.Data;
using System;
using System.Collections.Generic;
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

        public bool HasThreads { get; set; } = false;

        public List<Thread> Threads { get; set; } = new List<Thread>();
        public Dictionary<int, string> AbstractContents { get; set; } = new Dictionary<int, string>();

        protected override async Task OnInitializedAsync()
        {
            Threads = await DataService.GetLastNThreads();
            if (Threads.Any())
            {
                HasThreads = true;
            }
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await this.JSRuntime.InitNotePad();
                foreach(var thread in Threads)
                {
                    try
                    {
                        var text = await JSRuntime.GetPlainText(thread.Comments.FirstOrDefault()?.Content ?? string.Empty);
                        AbstractContents.Add(thread.Id, text);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Message : {e.Message}");
                    }
                }

                StateHasChanged();
            }
        }

        public void OpenNotePad()
        {
            Modal.ShowModal("create-note-modal");
        }
    }
}
