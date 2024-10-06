/*using Clinic.Core.Resources;
using Clinic.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Clinic.Core.Feautres.PatientCQRS.Commands.ValidatiorsCommands
{
    public class EditPatientValidator : AbstractValidator<AddPaitentCommand>
    {
        #region Fields
        private readonly IPatientService _PatientService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public EditPatientValidator(IPatientService PatientService,
                                    IStringLocalizer<SharedResources> localizer)
        {

            _PatientService = PatientService;
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
                 .MustAsync(async (Key, CancellationToken) => !await _PatientService.IsNameArExist(Key))
                 .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _PatientService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);


        }
        #endregion
    }
}
*/