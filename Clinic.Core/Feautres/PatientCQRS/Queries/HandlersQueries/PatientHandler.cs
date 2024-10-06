/*using AutoMapper;
using Clinic.Core.Bases;
using Clinic.Core.Feautres.PatientCQRS.Queries.ModelsQueries;
using Clinic.Core.Feautres.PatientCQRS.Queries.ResponseQueries;
using Clinic.Core.Resources;
using Clinic.Data.Entities;
using Clinic.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Clinic.Core.Feautres.PatientCQRS.Queries.HandlersQueries
{
    public class PatientHandler : ResponseHandler, IRequestHandler<GetListPatientQuery, Response<List<GetListPatientResponse>>>
    {
        private readonly IPatientService _PatientService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public PatientHandler(IPatientService PatientService,IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _PatientService=PatientService;
            _mapper=mapper;
            _stringLocalizer=stringLocalizer;
        }
       

        public async Task<Bases.Response<List<GetListPatientResponse>>> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
        {
            var paitentList = await _PatientService.GetPatientsListAsync();
            var paitentListMapper = _mapper.Map<List<GetListPatientResponse>>(paitentList);
            var result = Success(paitentListMapper);
            result.Meta = new { Count = paitentListMapper.Count() };
            return result;
        }

      
    }
}
*/