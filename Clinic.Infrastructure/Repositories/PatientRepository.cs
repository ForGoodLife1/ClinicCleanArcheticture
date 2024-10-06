using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories
{
    public class PatientRepository: GenericRepositoryAsync<Patient>,IPatientRepository
    {
        private readonly DbSet<Patient> _Patient;            
        public PatientRepository(ClinicDbContext dbContext) : base(dbContext)//base on GenericRepositoryAsync
        {
            _Patient=dbContext.Set<Patient>();
        }

        public async Task<List<Patient>> GetPatientsListAsync()
        {
            return await _Patient.ToListAsync();
        }
    }
}
