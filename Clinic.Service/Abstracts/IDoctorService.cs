using Clinic.Data.Entities;

namespace Clinic.Service.Abstracts
{
    public interface IDoctorService
    {
        public Task<List<Doctor>> GetDoctorsListAsync();
        public Task<Doctor> GetDoctorByIDWithIncludeAsync(int id);
        public Task<Doctor> GetByIDAsync(int id);
        public Task<string> AddAsync(Doctor doctor);

        public Task<string> EditAsync(Doctor doctor);
        public Task<string> DeleteAsync(Doctor doctor);
        public Task<bool> IsEmailExist(string email);
        public Task<bool> IsDoctorExistById(int Id);
        public IQueryable<Doctor> GetDoctorsQuerable();

        public IQueryable<Doctor> FilterDoctorPaginatedQuerable(string search);

    }
}
