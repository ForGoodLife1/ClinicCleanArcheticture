using Clinic.Data.Entities;
using Clinic.Data.Enums;

namespace Clinic.Service.Abstracts
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetPatientsListAsync();
        public Task<Patient> GetPatientByIDWithIncludeAsync(int id);
        public Task<Patient> GetByIDAsync(int id);
        public Task<string> AddAsync(Patient Patient);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Patient Patient);
        public Task<string> DeleteAsync(Patient Patient);
        public IQueryable<Patient> GetPatientsQuerable();
        public IQueryable<Patient> GetPatientsByPatientIDQuerable(int PID);
        public IQueryable<Patient> FilterPatientPaginatedQuerable(PatientOrderingEnum orderingEnum, string search);

    }
}
