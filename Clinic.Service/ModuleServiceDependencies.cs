using Clinic.Service.Abstracts;
using Clinic.Service.AuthServices.Implementations;
using Clinic.Service.AuthServices.Interfaces;
using Clinic.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailsService, EmailsService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IFileService, FileService>();
            return services;

        }

    }
}
