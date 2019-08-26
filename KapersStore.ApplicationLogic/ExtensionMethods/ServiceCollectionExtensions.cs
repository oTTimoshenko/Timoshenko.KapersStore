using KapersStore.ApplicationLogic.UserManagement;
using KapersStore.ApplicationLogic.UserManagement.Abstractions;
using KapersStore.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppDependencies(this IServiceCollection services)
        {
            services.AddDataContextDependencies();

            services.AddUserManagementDependencies();
        }

        public static void AddUserManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddDataContextDependencies(this IServiceCollection services)
        {
            //services.AddScoped<DataContext>();
        }
    }
}
