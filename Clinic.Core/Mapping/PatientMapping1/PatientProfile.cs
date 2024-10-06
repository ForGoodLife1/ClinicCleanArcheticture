using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Mapping.PatientMapping1
{
    public partial class PatientProfile : Profile
    {
        public PatientProfile()
        {
            GetPatientListMapping();
        }
    }
}
