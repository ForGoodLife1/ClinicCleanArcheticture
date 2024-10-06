using Clinic.Core.Bases;
using Clinic.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace Clinic.Core.Features.Authorization.Quaries.Models
{
    public class GetRolesListQuery : IRequest<Response<List<GetRolesListResult>>>
    {
    }
}
