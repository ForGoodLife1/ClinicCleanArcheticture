using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clinic.Service.Implementations
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository=prescriptionRepository;
        }

        public async Task<List<Prescription>> GetPrescriptionsListAsync()
        {
            return await _prescriptionRepository.GetPrescriptionsListAsync();
        }

        public async Task<Prescription> GetPrescriptionByIDWithIncludeAsync(int id)
        {
            // var Prescription = await _prescriptionRepository.GetByIdAsync(id);
            var Prescription = _prescriptionRepository.GetTableNoTracking()
                                          .Include(x => x.MedicalRecord)
                                          .Where(x => x.PrescriptionId.Equals(id))
                                          .FirstOrDefault();
            return Prescription;
        }

        public async Task<string> AddAsync(Prescription prescription)
        {
            //Added Prescription
            await _prescriptionRepository.AddAsync(prescription);
            return "Success";
        }




        public async Task<string> EditAsync(Prescription prescription)
        {
            await _prescriptionRepository.UpdateAsync(prescription);
            return "Success";
        }

        public async Task<string> DeleteAsync(Prescription prescription)
        {
            var trans = _prescriptionRepository.BeginTransaction();
            try
            {
                await _prescriptionRepository.DeleteAsync(prescription);
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

        public async Task<Prescription> GetByIDAsync(int id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            return prescription;
        }

        public IQueryable<Prescription> GetPrescriptionsQuerable()
        {
            return _prescriptionRepository.GetTableNoTracking().Include(x => x.MedicalRecord).AsQueryable();
        }

        public IQueryable<Prescription> FilterPrescriptionPaginatedQuerable(string search)
        {
            var querable = _prescriptionRepository.GetTableNoTracking().Include(x => x.MedicalRecord).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.Dosage.Contains(search) || x.MedicationNameEn.Contains(search));
            }
            return querable;
        }








    }
}
