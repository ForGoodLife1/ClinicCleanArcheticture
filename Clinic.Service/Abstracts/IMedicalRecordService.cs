using Clinic.Data.Entities;
using Clinic.Data.Enums;

namespace Clinic.Service.Abstracts
{
    public interface IMedicalRecordService
    {
        public Task<List<MedicalRecord>> GetMedicalRecordsListAsync();
        public Task<MedicalRecord> GetMedicalRecordByIDWithIncludeAsync(int id);
        public Task<MedicalRecord> GetByIDAsync(int id);
        public Task<string> AddAsync(MedicalRecord MedicalRecord);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(MedicalRecord MedicalRecord);
        public Task<string> DeleteAsync(MedicalRecord MedicalRecord);
        public IQueryable<MedicalRecord> GetMedicalRecordsQuerable();
        public IQueryable<MedicalRecord> GetMedicalRecordsByMedicalRecordIDQuerable(int PID);
        public IQueryable<MedicalRecord> FilterMedicalRecordPaginatedQuerable(PatientOrderingEnum orderingEnum, string search);

    }
}
