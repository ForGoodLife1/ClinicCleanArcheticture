/*
using AutoMapper;
using Clinic.Core.Bases;
using Clinic.Core.Feautres.PatientCQRS.Commands.ModelsCommands;
using Clinic.Core.Resources;
using Clinic.Data.Entities;
using Clinic.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Clinic.Core.Feautres.PatientCQRS.Commands.HandlersCommands
{
    public class PatientHandler : ResponseHandler
                                       , IRequestHandler<AddPatientCommand, Response<String>>
                                       , IRequestHandler<DeletePatientCommand, Response<String>>
                                       , IRequestHandler<EditPatientCommand, Response<String>>
    {
        #region Fields
        private readonly IPatientService _PatientService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public PatientHandler(IPatientService PatientService,
                                      IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _PatientService = PatientService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion
        public async Task<Response<string>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and Patient
            var Patientmapper = _mapper.Map<Patient>(request);
            //add
            var result = await _PatientService.AddAsync(Patientmapper);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var Patient = await _PatientService.GetByIDAsync(request.Id);
            if (Patient==null) return NotFound<string>();
            var result = await _PatientService.DeleteAsync(Patient);
            if (result=="Success") return Deleted<string>();
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var patient = await _PatientService.GetByIDAsync(request.Id);
            //return NotFound
            if (patient == null) return NotFound<string>();
            //mapping Between request and patient
            var patientmapper = _mapper.Map(request, patient);
            //Call service that make Edit
            var result = await _PatientService.EditAsync(patientmapper);
            //return response
            if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else return BadRequest<string>();
        }
    }
}
*/