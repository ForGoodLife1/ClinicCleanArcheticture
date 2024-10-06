using Clinic.Data.Entities;
using Clinic.Infarastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Abstracts
{
    public interface IPrescriptionRepository : IGenericRepositoryAsync<Prescription>
    {
        public Task<List<Prescription>> GetPrescriptionsListAsync();
    }
}
