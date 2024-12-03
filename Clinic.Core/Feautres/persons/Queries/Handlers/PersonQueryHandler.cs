using AutoMapper;
using Clinic.Core.Bases;
using Clinic.Core.Feautres.persons.Queries.Models;
using Clinic.Core.Feautres.persons.Queries.Responses;
using Clinic.Core.Resources;
using Clinic.Core.Wrappers;
using Clinic.Data.Entities;
using Clinic.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace Clinic.Core.Feautres.persons.Queries.Handlers
{
    public class PersonQueryHandler : ResponseHandler,
                                     IRequestHandler<GetListPersonQuery, Response<List<GetListPersonResponse>>>,
                                      IRequestHandler<GetPersonByIdQuery, Response<GetPersonByIdResponse>>,
                                       IRequestHandler<GetListPersonPaginatedQuery, PaginatedResult<GetPersonPaginatedResponse>>
    {
        #region Fields
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public PersonQueryHandler(IPersonService personService,
                                   IMapper mapper,
                                    IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)

        {
            _personService = personService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        public async Task<Response<List<GetListPersonResponse>>> Handle(GetListPersonQuery request, CancellationToken cancellationToken)
        {
            var PersonList = await _personService.GetPersonsListAsync();
            var PersonListMapper = _mapper.Map<List<GetListPersonResponse>>(PersonList);
            var result = Success(PersonListMapper);
            result.Meta = new { Count = PersonListMapper.Count() };
            return result;
        }

        public async Task<Response<GetPersonByIdResponse>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {

            var Person = await _personService.GetPersonByIDWithIncludeAsync(request.PersonId);
            if (Person == null) return NotFound<GetPersonByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetPersonByIdResponse>(Person);
            return Success(result);
        }

        public async Task<PaginatedResult<GetPersonPaginatedResponse>> Handle(GetListPersonPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Person, GetPersonPaginatedResponse>> expression = e => new GetPersonPaginatedResponse(e.PersonId, e.Localize(e.NameAr, e.NameEn), e.PhoneNumber, e.Email, e.Address);
            var querable = _personService.GetPersonsQuerable();
            var FilterQuery = _personService.FilterPersonPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
    }
}
