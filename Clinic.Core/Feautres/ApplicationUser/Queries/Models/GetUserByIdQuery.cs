using Clinic.Core.Bases;
using Clinic.Core.Features.ApplicationUser.Queries.Results;
using MediatR;

namespace Clinic.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
