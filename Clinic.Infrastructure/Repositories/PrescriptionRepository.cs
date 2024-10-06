using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories
{
    public class PrescriptionRepository: GenericRepositoryAsync<Prescription>,IPrescriptionRepository
    {
        private readonly DbSet<Prescription> _Prescription;            
        public PrescriptionRepository(ClinicDbContext dbContext) : base(dbContext)//base on GenericRepositoryAsync
        {
            _Prescription=dbContext.Set<Prescription>();
        }

        public async Task<List<Prescription>> GetPrescriptionsListAsync()
        {
            return await _Prescription.ToListAsync();
        }
    }
}
