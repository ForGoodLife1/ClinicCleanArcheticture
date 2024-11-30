using Clinic.Data.Entities;
using Clinic.Data.Enums;

namespace Clinic.Service.Abstracts
{
    public interface IPrescriptionService
    {
        public Task<List<Prescription>> GetPrescriptionsListAsync();
        public Task<Prescription> GetPrescriptionByIDWithIncludeAsync(int id);
        public Task<Prescription> GetByIDAsync(int id);
        public Task<string> AddAsync(Prescription Prescription);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Prescription Prescription);
        public Task<string> DeleteAsync(Prescription Prescription);
        public IQueryable<Prescription> GetPrescriptionsQuerable();
        public IQueryable<Prescription> GetPrescriptionsByPrescriptionIDQuerable(int PID);
        public IQueryable<Prescription> FilterPrescriptionPaginatedQuerable(PatientOrderingEnum orderingEnum, string search);

    }
}
