﻿using BlazorToastify;
using Microsoft.Extensions.DependencyInjection;
using Note.Interfaces;
using Note.Services;

namespace Note.Web.Extensions
{
    public static class ServiceRegistry
    {
        /// <summary>
        /// Registers all services, which are later injected in the constructor.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IJSIntrop, JSIntropService>();
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IQuickNoteModal, QuickNoteModalService>();
            services.AddToasts();
            services.AddTransient<IToaster, Toaster>();
        }
    }
}
