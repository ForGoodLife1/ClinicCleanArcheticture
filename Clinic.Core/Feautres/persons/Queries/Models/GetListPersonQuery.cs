using Clinic.Core.Bases;
using Clinic.Core.Feautres.persons.Queries.Responses;
using MediatR;

namespace Clinic.Core.Feautres.persons.Queries.Models
{
    public class GetListPersonQuery : IRequest<Response<List<GetListPersonResponse>>>
    {

    }
}
