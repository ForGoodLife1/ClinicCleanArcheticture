using Clinic.Core.Bases;
using Clinic.Data.DTOs;
using MediatR;

namespace Clinic.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Response<string>>
    {
    }
}
