using BlazorToastify;
using Note.Interfaces;

namespace Note.Services
{
    public class Toaster : IToaster
    {
        private readonly IToastService _toastService;
        public Toaster(IToastService toastService)
        {
            _toastService = toastService;
        }

        public void Success(string message)
        {
            _toastService.AddToastAsync(
                message: message,
                type: "success",
                animation: "fade",
                autoClose: 4000
            );
        }

        public void Error(string message)
        {
            _toastService.AddToastAsync(
                message: message,
                type: "error",
                animation: "fade",
                autoClose: 4000
            );
        }
    }
}
