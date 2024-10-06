﻿using Clinic.Core.Bases;
using Clinic.Data.Results;
using MediatR;

namespace Clinic.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}