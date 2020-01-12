using Microsoft.AspNetCore.Components;
using Note.Interfaces;
using Note.Models;
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
        NavigationManager NavigationManager { get; set; }

        [Inject]
        IDataService DataService { get; set; }

        [Inject]
        IJSIntrop JSRuntime { get; set; }

        [Inject]
        IQuickNoteModal Modal { get; set; }

        public bool HasThreads { get; set; } = false;

        public List<Thread> Threads { get; set; } = new List<Thread>();
        public Dictionary<int, AbstractNoteModel> AbstractContents { get; set; } = new Dictionary<int, AbstractNoteModel>();

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
                foreach (var thread in Threads)
                {
                    try
                    {
                        var data = await JSRuntime.GetPlainText(thread.Comments.FirstOrDefault()?.Content ?? string.Empty);
                        AbstractContents.Add(thread.Id, new AbstractNoteModel
                        {
                            Lines = data.Split("\n").ToList(),
                            Title = thread.Title
                        });
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

        public void OpenThread(int id)
        {
           NavigationManager.NavigateTo($"/thread/{id}");
        }
    }
}
