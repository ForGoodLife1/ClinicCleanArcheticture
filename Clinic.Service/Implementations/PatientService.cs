using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clinic.Service.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository=patientRepository;
        }

        public async Task<List<Patient>> GetPatientsListAsync()
        {
            return await _patientRepository.GetPatientsListAsync();
        }

        public async Task<Patient> GetPatientByIDWithIncludeAsync(int id)
        {
            // var Patient = await _patientRepository.GetByIdAsync(id);
            var Patient = _patientRepository.GetTableNoTracking()
                                          .Include(x => x.Appointments)
                                          .Where(x => x.PatientId.Equals(id))
                                          .FirstOrDefault();
            return Patient;
        }

        public async Task<string> AddAsync(Patient patient)
        {
            //Added Patient
            await _patientRepository.AddAsync(patient);
            return "Success";
        }
        public async Task<string> EditAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
            return "Success";
        }
        public async Task<string> DeleteAsync(Patient patient)
        {
            var trans = _patientRepository.BeginTransaction();
            try
            {
                await _patientRepository.DeleteAsync(patient);
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
        public async Task<Patient> GetByIDAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            return patient;
        }

        public IQueryable<Patient> GetPatientsQuerable()
        {
            return _patientRepository.GetTableNoTracking().Include(x => x.Appointments).AsQueryable();
        }
    }
}
