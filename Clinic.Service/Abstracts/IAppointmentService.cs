using Clinic.Data.Entities;
using Clinic.Data.Enums;

namespace Clinic.Service.Abstracts
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> GetAppointmentsListAsync();
        public Task<Appointment> GetAppointmentByIDWithIncludeAsync(int id);
        public Task<Appointment> GetByIDAsync(int id);
        public Task<string> AddAsync(Appointment Appointment);
        public Task<string> EditAsync(Appointment Appointment);
        public Task<string> DeleteAsync(Appointment Appointment);
        public Task<bool> IsAppointmentExistByIdAsync(int Id);
        public IQueryable<Appointment> FilterAppointmentPaginatedQuerable(AppointmentOrderingEnum orderingEnum, string search);
    }
}
