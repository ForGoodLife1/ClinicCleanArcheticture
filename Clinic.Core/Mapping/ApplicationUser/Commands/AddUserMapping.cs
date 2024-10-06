using Clinic.Core.Features.ApplicationUser.Commands.Models;
using Clinic.Data.Entities.Identity;

namespace Clinic.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}