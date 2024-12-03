using Clinic.Core.Feautres.persons.Commands.Models;
using Clinic.Core.Resources;
using Clinic.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Clinic.Core.Feautres.persons.Commands.Validatiors
{
    public class EditPersonVaildator : AbstractValidator<EditPersonCommand>
    {
        #region Fields
        private readonly IPersonService _PersonService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public EditPersonVaildator(IPersonService PersonService,
                                    IStringLocalizer<SharedResources> localizer)
        {

            _PersonService = PersonService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region Action
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

        }
        public void ApplyCustomValidationsRules()
        {

            RuleFor(x => x.NameAr)
                 .MustAsync(async (Key, CancellationToken) => !await _PersonService.IsNameArExist(Key))
                 .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _PersonService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);


        }
        #endregion
    }
}
