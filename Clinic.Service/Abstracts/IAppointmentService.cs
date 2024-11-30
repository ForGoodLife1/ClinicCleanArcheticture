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
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Appointment Appointment);
        public Task<string> DeleteAsync(Appointment Appointment);
        public IQueryable<Appointment> GetAppointmentsQuerable();
        public IQueryable<Appointment> GetAppointmentsByAppointmentIDQuerable(int PID);
        public IQueryable<Appointment> FilterAppointmentPaginatedQuerable(PatientOrderingEnum orderingEnum, string search);

    }
}
