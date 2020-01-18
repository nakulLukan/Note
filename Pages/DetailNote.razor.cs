using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Note.Interfaces;
using Note.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Pages
{
    public class DetailNoteBase : ComponentBase
    {
        [Parameter]
        public string threadId { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IToaster Toaster { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public Thread Thread { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Thread = await DataService.GetThreadById(int.Parse(threadId));
            if (Thread == null)
            {
                Toaster.Error("Thread not found");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await JSRuntime.InvokeVoidAsync("ContentPad", "#content-container", Thread.Comments.FirstOrDefault().Content);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
