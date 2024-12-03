using AutoMapper;

namespace Clinic.Core.Mapping.Persons
{
    public partial class PersonProfile : Profile
    {
        public PersonProfile()
        {
            GetPersonListMapping();
            GetPersonByIDMapping();
            AddPersonCommandMapping();
            EditPersonCommandMapping();
        }
    }
}
