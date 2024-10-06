using Clinic.Core.Bases;
using Clinic.Data.Requests;
using MediatR;

namespace Clinic.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
