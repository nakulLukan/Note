﻿using Note.Web.Data;
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
            //services.AddTransient<NoteDbContext, NoteDbContext>();
            services.AddTransient<IDataService, DataService>();
        }
    }
}