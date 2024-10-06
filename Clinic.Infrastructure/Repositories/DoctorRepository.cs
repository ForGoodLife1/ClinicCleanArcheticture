using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories
{
    public class DoctorRepository: GenericRepositoryAsync<Doctor>,IDoctorRepository
    {
        private readonly DbSet<Doctor> _Doctor;            
        public DoctorRepository(ClinicDbContext dbContext) : base(dbContext)//base on GenericRepositoryAsync
        {
            _Doctor=dbContext.Set<Doctor>();
        }

        public async Task<List<Doctor>> GetDoctorsListAsync()
        {
            return await _Doctor.Include(x=>x.Appointments).ToListAsync();
        }
    }
}
