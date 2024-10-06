using Clinic.Data.Entities;
using Clinic.Infarastructure.InfrastructureBases;

namespace Clinic.Infrastructure.Abstracts
{
    public interface IAppointmentRepository : IGenericRepositoryAsync<Appointment>
    {
        public Task<List<Appointment>> GetAppointmentsListAsync();
    }
}
