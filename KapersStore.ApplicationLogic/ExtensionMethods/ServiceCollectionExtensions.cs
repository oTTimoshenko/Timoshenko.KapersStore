using KapersStore.ApplicationLogic.KaperManagement;
using KapersStore.ApplicationLogic.KaperManagement.Abstractions;
using KapersStore.ApplicationLogic.UserManagement;
using KapersStore.ApplicationLogic.UserManagement.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace KapersStore.ApplicationLogic.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppDependencies(this IServiceCollection services)
        {
            services.AddDataContextDependencies();

            services.AddUserManagementDependencies();
            services.AddKaperManagementDependencies();
        }

        public static void AddUserManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddKaperManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IKaperService, KaperService>();
        }

        public static void AddDataContextDependencies(this IServiceCollection services)
        {
            //services.AddScoped<DataContext>();
        }
    }
}
