using Clinic.Data.Entities;
using Clinic.Infarastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Abstracts
{
    public interface IMedicalRecordRepository : IGenericRepositoryAsync<MedicalRecord>
    {
        public Task<List<MedicalRecord>> GetMedicalRecordsListAsync();
    }
}
