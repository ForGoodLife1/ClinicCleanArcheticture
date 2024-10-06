/*using Clinic.Core.Feautres.PatientCQRS.Queries.ModelsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaitentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaitentController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("/Paitent/List")]
        public async Task<IActionResult> GetPaitentsAync()
        {
            var response = _mediator.Send(new GetListPatientQuery());
            return Ok(response);
        }
    }
}
*/