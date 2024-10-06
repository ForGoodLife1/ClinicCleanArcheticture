﻿using Clinic.Core.Features.Authorization.Quaries.Results;
using Clinic.Data.Entities.Identity;

namespace Clinic.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<Role, GetRoleByIdResult>();
        }
    }
}
