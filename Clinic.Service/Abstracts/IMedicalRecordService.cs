using Clinic.Data.Entities;

namespace Clinic.Service.Abstracts
{
    public interface IMedicalRecordService
    {
        public Task<List<MedicalRecord>> GetMedicalRecordsListAsync();
        public Task<MedicalRecord> GetMedicalRecordByIDWithIncludeAsync(int id);
        public Task<MedicalRecord> GetByIDAsync(int id);
        public Task<string> AddAsync(MedicalRecord MedicalRecord);

        public Task<string> EditAsync(MedicalRecord MedicalRecord);
        public Task<string> DeleteAsync(MedicalRecord MedicalRecord);
        public IQueryable<MedicalRecord> GetMedicalRecordsQuerable();

    }
}
