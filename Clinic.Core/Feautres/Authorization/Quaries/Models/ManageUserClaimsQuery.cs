using Clinic.Core.Bases;
using Clinic.Data.Results;
using MediatR;

namespace Clinic.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
