namespace Clinic.Core.Feautres.persons.Queries.Responses
{
    public class GetPersonByIdResponse
    {
        public int PersonId { get; set; }
        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
