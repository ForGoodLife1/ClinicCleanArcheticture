﻿using Clinic.Api.Base;
using Clinic.Core.Features.Emails.Commands.Models;
using Clinic.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.EmailsRoute.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
