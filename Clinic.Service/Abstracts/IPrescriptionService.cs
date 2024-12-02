using Clinic.Data.Entities;

namespace Clinic.Service.Abstracts
{
    public interface IPrescriptionService
    {
        public Task<List<Prescription>> GetPrescriptionsListAsync();
        public Task<Prescription> GetPrescriptionByIDWithIncludeAsync(int id);
        public Task<Prescription> GetByIDAsync(int id);
        public Task<string> AddAsync(Prescription Prescription);
        public Task<string> EditAsync(Prescription Prescription);
        public Task<string> DeleteAsync(Prescription Prescription);
        public IQueryable<Prescription> GetPrescriptionsQuerable();
        public IQueryable<Prescription> FilterPrescriptionPaginatedQuerable(string search);

    }
}
