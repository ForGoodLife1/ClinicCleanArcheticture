using Clinic.Data.Entities;
using Clinic.Data.Enums;

namespace Clinic.Service.Abstracts
{
    public interface IDoctorService
    {
        public Task<List<Doctor>> GetDoctorsListAsync();
        public Task<Doctor> GetDoctorByIDWithIncludeAsync(int id);
        public Task<Doctor> GetByIDAsync(int id);
        public Task<string> AddAsync(Doctor Doctor);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Doctor Doctor);
        public Task<string> DeleteAsync(Doctor Doctor);
        public IQueryable<Doctor> GetDoctorsQuerable();
        public IQueryable<Doctor> GetDoctorsByDoctorIDQuerable(int PID);
        public IQueryable<Doctor> FilterDoctorPaginatedQuerable(PatientOrderingEnum orderingEnum, string search);

    }
}
