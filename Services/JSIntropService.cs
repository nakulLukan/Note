using Microsoft.JSInterop;
using Note.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Services
{
    public class JSIntropService : IJSIntrop
    {
        protected IJSRuntime _runtime;
        public JSIntropService(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public Task<string> GetPlainText(string quillContents)
        {
            return _runtime.InvokeAsync<string>("GetPlainText", quillContents).AsTask();
        }

        public async Task InitNotePad()
        {
           await _runtime.InvokeVoidAsync("InitNotePad", "#editor-container");
        }
    }
}
