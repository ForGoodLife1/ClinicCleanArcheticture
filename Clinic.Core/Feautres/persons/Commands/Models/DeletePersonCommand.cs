using Clinic.Core.Bases;
using MediatR;

namespace Clinic.Core.Feautres.persons.Commands.Models
{
    public class DeletePersonCommand : IRequest<Response<string>>
    {
        public int PersonId { get; set; }
        public DeletePersonCommand(int personid)
        {
            PersonId = personid;
        }
    }
}
