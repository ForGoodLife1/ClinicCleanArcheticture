using Clinic.Core.Feautres.persons.Queries.Responses;
using Clinic.Data.Entities;

namespace Clinic.Core.Mapping.Persons
{
    public partial class PersonProfile
    {
        public void GetPersonByIDMapping()
        {
            CreateMap<Person, GetPersonByIdResponse>();
        }
    }
}
