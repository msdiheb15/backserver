using System;
using Data.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IOc
{
    public static  class DependencyContainer
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<DbContext>();
            services.AddTransient<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddTransient<IGenericRepository<Projet>, GenericRepository<Projet>>();
            services.AddTransient<IGenericRepository<Role>, GenericRepository<Role>>();
            services.AddTransient<IGenericRepository<Tache>, GenericRepository<Tache>>();
            services.AddTransient<IGenericRepository<TimesSheet>, GenericRepository<TimesSheet>>();
            services.AddTransient<IGenericRepository<ServiceDepartment>, GenericRepository<ServiceDepartment>>();
            //services.AddTransient<IUserDataService, UserDataService>();
        }

    }
}
