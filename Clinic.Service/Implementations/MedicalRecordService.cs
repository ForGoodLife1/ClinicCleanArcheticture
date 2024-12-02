using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clinic.Service.Implementations
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsListAsync()
        {
            return await _medicalRecordRepository.GetMedicalRecordsListAsync();
        }

        public async Task<MedicalRecord> GetMedicalRecordByIDWithIncludeAsync(int id)
        {
            // var MedicalRecord = await _medicalRecordRepository.GetByIdAsync(id);
            var MedicalRecord = _medicalRecordRepository.GetTableNoTracking()
                                          .Include(x => x.Appointments)
                                          .Include(x => x.Prescriptions)
                                          .Where(x => x.MedicalRecordId.Equals(id))
                                          .FirstOrDefault();
            return MedicalRecord;
        }

        public async Task<string> AddAsync(MedicalRecord MedicalRecord)
        {
            //Added MedicalRecord
            await _medicalRecordRepository.AddAsync(MedicalRecord);
            return "Success";
        }




        public async Task<string> EditAsync(MedicalRecord MedicalRecord)
        {
            await _medicalRecordRepository.UpdateAsync(MedicalRecord);
            return "Success";
        }

        public async Task<string> DeleteAsync(MedicalRecord MedicalRecord)
        {
            var trans = _medicalRecordRepository.BeginTransaction();
            try
            {
                await _medicalRecordRepository.DeleteAsync(MedicalRecord);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }

        }

        public async Task<MedicalRecord> GetByIDAsync(int id)
        {
            var MedicalRecord = await _medicalRecordRepository.GetByIdAsync(id);
            return MedicalRecord;
        }

        public IQueryable<MedicalRecord> GetMedicalRecordsQuerable()
        {
            return _medicalRecordRepository.GetTableNoTracking().Include(x => x.Prescriptions)
                                                                .Include(x => x.Appointments).AsQueryable();
        }
    }
}
