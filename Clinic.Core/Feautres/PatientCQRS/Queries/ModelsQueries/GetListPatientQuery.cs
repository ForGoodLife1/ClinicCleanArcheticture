using Clinic.Core.Bases;
using Clinic.Core.Feautres.PatientCQRS.Queries.ResponseQueries;
using Clinic.Data.Entities;
using MediatR;

namespace Clinic.Core.Feautres.PatientCQRS.Queries.ModelsQueries
{
    public class GetListPatientQuery : IRequest<Response<List<GetListPatientResponse>>>
    {
    }
}
