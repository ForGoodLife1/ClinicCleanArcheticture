using Clinic.Api.Base;
using Clinic.Core.Feautres.persons.Commands.Models;
using Clinic.Core.Feautres.persons.Queries.Models;
using Clinic.Core.Filters;
using Clinic.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{

    [ApiController]
    public class PersonController : AppControllerBase
    {
        [HttpGet(Router.PersonRouting.List)]
        [Authorize(Roles = "User")]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> GetPersonList()
        {
            var response = await Mediator.Send(new GetListPersonQuery());
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet(Router.PersonRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetListPersonPaginatedQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.PersonRouting.GetByID)]
        public async Task<IActionResult> GetPersonByID([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetPersonByIdQuery(id)));
        }
        [Authorize(Policy = "CreatePerson")]
        [HttpPost(Router.PersonRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPersonCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Policy = "EditPerson")]
        [HttpPut(Router.PersonRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPersonCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Policy = "DeletePerson")]
        [HttpDelete(Router.PersonRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeletePersonCommand(id)));
        }
    }
}

