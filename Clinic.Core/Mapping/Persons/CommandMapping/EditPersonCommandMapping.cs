using Clinic.Core.Feautres.persons.Commands.Models;
using Clinic.Data.Entities;

namespace Clinic.Core.Mapping.Persons
{
    public partial class PersonProfile
    {
        public void EditPersonCommandMapping()
        {
            CreateMap<EditPersonCommand, Person>();
        }
    }
}
