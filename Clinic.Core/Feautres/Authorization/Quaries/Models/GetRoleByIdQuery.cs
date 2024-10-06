using Clinic.Core.Bases;
using Clinic.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace Clinic.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public int Id { get; set; }
    }
}
