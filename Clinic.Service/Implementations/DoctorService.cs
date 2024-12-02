using Clinic.Data.Entities;
using Clinic.Infrastructure.Abstracts;
using Clinic.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clinic.Service.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<Doctor>> GetDoctorsListAsync()
        {
            return await _doctorRepository.GetDoctorsListAsync();
        }

        public async Task<Doctor> GetDoctorByIDWithIncludeAsync(int id)
        {
            // var Doctor = await _doctorRepository.GetByIdAsync(id);
            var Doctor = _doctorRepository.GetTableNoTracking()
                                          .Include(x => x.Person)
                                          .Include(x => x.Appointments)
                                          .Where(x => x.DoctorId.Equals(id))
                                          .FirstOrDefault();
            return Doctor;
        }

        public async Task<string> AddAsync(Doctor doctor)
        {
            //Added Doctor
            await _doctorRepository.AddAsync(doctor);
            return "Success";
        }




        public async Task<string> EditAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
            return "Success";
        }

        public async Task<string> DeleteAsync(Doctor doctor)
        {
            var trans = _doctorRepository.BeginTransaction();
            try
            {
                await _doctorRepository.DeleteAsync(doctor);
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

        public async Task<Doctor> GetByIDAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            return doctor;
        }

        public IQueryable<Doctor> GetDoctorsQuerable()
        {
            return _doctorRepository.GetTableNoTracking().AsQueryable();
        }

        public IQueryable<Doctor> FilterDoctorPaginatedQuerable(string search)
        {
            var querable = _doctorRepository.GetTableNoTracking().AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.Person.NameAr.ToLower() == search.ToLower()
                   || x.Person.NameEn.ToLower() == search.ToLower() || x.Person.Email.ToLower() == search.ToLower());
            }
            return querable;
        }


        public IQueryable<Doctor> GetDoctorsByPatientIDQuerable(int PID)
        {
            return _doctorRepository.GetTableNoTracking().Where(x => x.Person.PersonId.Equals(PID)).AsQueryable();
        }


        public async Task<bool> IsEmailExist(string email)
        {
            var result = await _doctorRepository.GetTableNoTracking().Where(x => x.Person.Email.Equals(email)).FirstOrDefaultAsync();
            if (result == null)
                return false;

            return true;
        }

        public async Task<bool> IsDoctorExistById(int Id)
        {
            var result = await _doctorRepository.GetTableNoTracking().Where(x => x.DoctorId == Id).FirstOrDefaultAsync();
            if (result == null)
                return false;

            return true;
        }
    }
}
