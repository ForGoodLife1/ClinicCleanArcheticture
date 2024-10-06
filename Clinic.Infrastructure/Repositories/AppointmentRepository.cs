using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Infrastructure.AppDbContext;
using Clinic.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepositoryAsync<Appointment>,IAppointmentRepository
    {
        private readonly DbSet<Appointment> _Appointment;            
        public AppointmentRepository(ClinicDbContext dbContext) : base(dbContext)//base on GenericRepositoryAsync
        {
            _Appointment=dbContext.Set<Appointment>();
        }

        public async Task<List<Appointment>> GetAppointmentsListAsync()
        {
            return await _Appointment.ToListAsync();
        }
    }
}
