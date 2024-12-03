using AutoMapper;
using Clinic.Core.Bases;
using Clinic.Core.Feautres.persons.Commands.Models;
using Clinic.Core.Resources;
using Clinic.Data.Entities;
using Clinic.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Clinic.Core.Feautres.persons.Commands.Handlers
{
    public class PerosnCommandHandler : ResponseHandler,
                                      IRequestHandler<AddPersonCommand, Response<string>>,
                                        IRequestHandler<EditPersonCommand, Response<string>>,
                                         IRequestHandler<DeletePersonCommand, Response<string>>
    {
        #region Fields
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public PerosnCommandHandler(IPersonService PersonService,
                                      IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _personService = PersonService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and Person
            var Personmapper = _mapper.Map<Person>(request);
            //add
            var result = await _personService.AddAsync(Personmapper);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();




        }

        public async Task<Response<string>> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Person = await _personService.GetByIDAsync(request.PersonId);
            //return NotFound
            if (Person == null) return NotFound<string>();
            //mapping Between request and Person
            var Personmapper = _mapper.Map(request, Person);
            //Call service that make Edit
            var result = await _personService.EditAsync(Personmapper);
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var Person = await _personService.GetByIDAsync(request.PersonId);
            //return NotFound
            if (Person == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _personService.DeleteAsync(Person);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
        #endregion
    }
}
