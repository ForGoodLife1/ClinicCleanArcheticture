using Clinic.Core.Feautres.PatientCQRS.Queries.ResponseQueries;
using Clinic.Data.Entities;
namespace Clinic.Core.Mapping.PatientMapping1
{
    public partial class PatientProfile
    {
        public void GetPatientListMapping()
        {
            CreateMap<Patient, GetListPatientResponse>();
        }
    }
}
