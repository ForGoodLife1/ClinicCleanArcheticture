using Clinic.Core.Features.ApplicationUser.Queries.Results;
using Clinic.Data.Entities.Identity;

namespace Clinic.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
