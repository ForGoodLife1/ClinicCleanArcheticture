using Clinic.Data.Entities;
using Clinic.Data.Enums;
using Clinic.Infrastructure.Abstracts;
using Clinic.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Clinic.Service.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository AppointmentRepository)
        {
            _appointmentRepository=AppointmentRepository;
        }

        public async Task<List<Appointment>> GetAppointmentsListAsync()
        {
            return await _appointmentRepository.GetAppointmentsListAsync();
        }

        public async Task<Appointment> GetAppointmentByIDWithIncludeAsync(int id)
        {
            // var Appointment = await _appointmentRepository.GetByIdAsync(id);
            var appointment = _appointmentRepository.GetTableNoTracking()
                                         .Include(x => x.Doctor)
                                         .Include(x => x.MedicalRecord)
                                         .Include(x => x.Patient)
                                         .Include(x => x.Payment)
                                         .Where(x => x.AppointmentId.Equals(id))
                                         .FirstOrDefault();
            return appointment;
        }

        public async Task<string> AddAsync(Appointment appointment)
        {
            //Added Appointment
            await _appointmentRepository.AddAsync(appointment);
            return "Success";
        }




        public async Task<string> EditAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
            return "Success";
        }

        public async Task<string> DeleteAsync(Appointment appointment)
        {
            var trans = _appointmentRepository.BeginTransaction();
            try
            {
                await _appointmentRepository.DeleteAsync(appointment);
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

        public async Task<Appointment> GetByIDAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            return appointment;
        }

        public IQueryable<Appointment> GetAppointmentsQuerable()
        {
            return _appointmentRepository.GetTableNoTracking().Include(x => x.Doctor)
                                                                      .Include(x => x.MedicalRecord)
                                                                      .Include(x => x.Patient)
                                                                      .Include(x => x.Payment).AsQueryable();
        }

        public IQueryable<Appointment> FilterAppointmentPaginatedQuerable(AppointmentOrderingEnum orderingEnum, string search)
        {
            var querable = _appointmentRepository.GetTableNoTracking().Include(x => x.Doctor)
                                                                      .Include(x => x.MedicalRecord)
                                                                      .Include(x => x.Patient)
                                                                      .Include(x => x.Payment).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.Doctor.Person.NameAr.Contains(search) || x.Doctor.Person.NameEn.Contains(search));
            }
            switch (orderingEnum)
            {
                case AppointmentOrderingEnum.AppointmentDateTime:
                    querable = querable.OrderBy(x => x.AppointmentDateTime);
                    break;
                case AppointmentOrderingEnum.AppointmentStatus:
                    querable = querable.OrderBy(x => x.AppointmentStatus);
                    break;
            }

            return querable;
        }

        public async Task<bool> IsAppointmentExistByIdAsync(int Id)
        {
            var result = await _appointmentRepository.GetTableNoTracking()
                      .Where(x => x.AppointmentId == Id).FirstOrDefaultAsync();
            if (result == null)
                return false;


            return true;
        }
    }
}
