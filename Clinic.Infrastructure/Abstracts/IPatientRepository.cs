using Clinic.Data.Entities;
using Clinic.Infarastructure.InfrastructureBases;

namespace Clinic.Infrastructure.Abstracts
{
    public interface IPatientRepository : IGenericRepositoryAsync<Patient>
    {
        public Task<List<Patient>> GetPatientsListAsync();
    }
}
