using Clinic.Core.Feautres.PatientCQRS.Queries.ResponseQueries;
using Clinic.Core.Wrappers;
using Clinic.Data.Enums;
using MediatR;

namespace Clinic.Core.Feautres.PatientCQRS.Queries.ModelsQueries
{
    public class GetListPatientPaginatedQuery : IRequest<PaginatedResult<GetPatientPaginatedListResopnse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PatientOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
