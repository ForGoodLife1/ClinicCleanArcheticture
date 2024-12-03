using Clinic.Core.Bases;
using Clinic.Core.Feautres.persons.Queries.Responses;
using MediatR;

namespace Clinic.Core.Feautres.persons.Queries.Models
{
    public class GetPersonByIdQuery : IRequest<Response<GetPersonByIdResponse>>
    {
        public int PersonId { get; set; }
        public GetPersonByIdQuery(int personid)
        {
            PersonId = personid;
        }
    }
}
