using Clinic.Core.Features.ApplicationUser.Queries.Results;
using Clinic.Core.Wrappers;
using MediatR;

namespace Clinic.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationReponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
