using KapersStore.ApplicationLogic.CartManagement;
using KapersStore.ApplicationLogic.CartManagement.Abstractions;
using KapersStore.ApplicationLogic.KaperManagement;
using KapersStore.ApplicationLogic.KaperManagement.Abstractions;
using KapersStore.ApplicationLogic.MailManagement;
using KapersStore.ApplicationLogic.MailManagement.Abstractions;
using KapersStore.ApplicationLogic.PurchaseManagement;
using KapersStore.ApplicationLogic.PurchaseManagement.Abstractions;
using KapersStore.ApplicationLogic.UserManagement;
using KapersStore.ApplicationLogic.UserManagement.Abstractions;
using KapersStore.Infrastructure.Helpers.MailSender;
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
            services.AddMailManagementDependencies();
            services.AddPurchaseManagementDependencies();
        }

        public static void AddUserManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddKaperManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IKaperService, KaperService>();
        }

        public static void AddCartManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
        }

        public static void AddMailManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMailSender, MailKitSender>();
        }

        public static void AddPurchaseManagementDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPurchaseService, PurchaseService>();
        }

        public static void AddDataContextDependencies(this IServiceCollection services)
        {
            //services.AddScoped<DataContext>();
        }
    }
}
