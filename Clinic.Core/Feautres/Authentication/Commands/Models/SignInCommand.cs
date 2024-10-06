
using Clinic.Core.Bases;
using Clinic.Data.Results;
using MediatR;

namespace Clinic.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
