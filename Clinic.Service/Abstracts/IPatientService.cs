﻿using Clinic.Data.Entities;

namespace Clinic.Service.Abstracts
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetPatientsListAsync();
        public Task<Patient> GetPatientByIDWithIncludeAsync(int id);
        public Task<Patient> GetByIDAsync(int id);
        public Task<string> AddAsync(Patient Patient);

        public Task<string> EditAsync(Patient Patient);
        public Task<string> DeleteAsync(Patient Patient);
        public IQueryable<Patient> GetPatientsQuerable();



    }
}
