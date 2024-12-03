using Clinic.Core.Feautres.persons.Queries.Responses;
using Clinic.Core.Wrappers;
using Clinic.Data.Enums;
using MediatR;

namespace Clinic.Core.Feautres.persons.Queries.Models
{
    public class GetListPersonPaginatedQuery : IRequest<PaginatedResult<GetPersonPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PersonOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }

    }
}
