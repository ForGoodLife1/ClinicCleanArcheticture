namespace Clinic.Core.Feautres.persons.Queries.Responses
{
    public class GetPersonPaginatedResponse
    {
        public GetPersonPaginatedResponse(int personId, string name, string phoneNumber, string? email, string? address)
        {
            PersonId=personId;
            Name=name;
            PhoneNumber=phoneNumber;
            Email=email;
            Address=address;
        }

        public int PersonId { get; set; }
        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }


    }
}
