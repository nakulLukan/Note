using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Note.Interfaces;
using Note.Web.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Note.Pages
{
    public class QuickNoteBase : ComponentBase
    {
        [Inject]
        IDataService DataService { get; set; }

        [Inject]
        IJSRuntime JSRuntime { get; set; }


        [Inject]
        IQuickNoteModal NoteModalService { get; set; }

        protected Thread Note { get; set; } = new Thread();

        protected List<Tag> Tags = new List<Tag>();
        protected List<string> SuggestedTags = new List<string>();

        protected string TagName = string.Empty;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                RefreshSuggestedTags();
            }
        }

        private void RefreshSuggestedTags()
        {
            Task.Run(async () =>
            {
                SuggestedTags = await DataService.GetSuggestedTags();
                StateHasChanged();
            });
        }

        /// <summary>
        /// Save note.
        /// </summary>
        /// <returns></returns>
        protected async Task SaveNote()
        {
            var content = await JSRuntime.InvokeAsync<string>("GetNotePadContents");
            Note.Comments.Add(new Comment()
            {
                Content = content,
                UpdateAt = DateTime.Now,
                CreatedAt = DateTime.Now,
            });

            Note.Tags = GetAssociatedTags(Note);
            DataService.SaveNote(Note);

            CloseQuickNoteModal();
        }

        protected void CloseQuickNoteModal()
        {
            NoteModalService.ClearContent();
            NoteModalService.HideModal("create-note-modal");

            Note = new Thread();
            Tags.Clear();
            RefreshSuggestedTags();
        }

        private List<ThreadTag> GetAssociatedTags(Thread note)
        {
            List<ThreadTag> associatedTags = new List<ThreadTag>();
            foreach(var tag in Tags)
            {
                associatedTags.Add(new ThreadTag
                {
                    Thread = note,
                    Tag = tag
                });
            }

            return associatedTags;
        }

        protected void AddTag()
        {
            if (!string.IsNullOrEmpty(TagName))
            {
                if(!Tags.Exists(x => x.Name.ToLower() == TagName.ToLower()))
                {
                    var tag = DataService.GetTagByName(TagName.ToLower());
                    Tags.Add(tag);
                }
                
                TagName = string.Empty;
                StateHasChanged();
            }
        }

        protected void KeyPressEvent(KeyboardEventArgs e)
        {
            if(e.Key == "Enter")
            {
                AddTag();
            }
        }
    }
}
