using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories
{
    public class MedicalRecordRepository: GenericRepositoryAsync<MedicalRecord>,IMedicalRecordRepository
    {
        private readonly DbSet<MedicalRecord> _MedicalRecord;            
        public MedicalRecordRepository(ClinicDbContext dbContext) : base(dbContext)//base on GenericRepositoryAsync
        {
            _MedicalRecord=dbContext.Set<MedicalRecord>();
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsListAsync()
        {
            return await _MedicalRecord./*Include(x=>x.Prescription).*/ToListAsync();
        }
    }
}
/*Appointment

Prescription*/