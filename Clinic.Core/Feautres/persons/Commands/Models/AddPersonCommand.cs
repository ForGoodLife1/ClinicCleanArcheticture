using Clinic.Core.Bases;
using MediatR;

namespace Clinic.Core.Feautres.persons.Commands.Models
{
    public class AddPersonCommand : IRequest<Response<string>>
    {
        public int PersonId { get; set; }

        public string NameAr { get; set; } = null!;
        public string NameEn { get; set; } = null!;

        public DateOnly? DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
