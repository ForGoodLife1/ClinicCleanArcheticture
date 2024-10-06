using Clinic.Infarastructure.InfrastructureBases;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.InfrastructureBases;
using Clinic.Infrastructure.Repositories;
using Clinic.Infrustructure.Abstracts;
using Clinic.Infrustructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infarastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;

        }
    }
}
