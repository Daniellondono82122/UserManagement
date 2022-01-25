namespace UserManagement.Services.Validators.CommandValidators.StateCommandValidators
{
    using Domain.Commands.StateCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class RegisterStateCommandValidator : AbstractValidator<RegisterStateCommand>
    {
        public RegisterStateCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("State Name has cannot be empty");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Address has cannot be empty");

            RuleFor(preference => preference.CountryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (countryId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<Country>(u => u.CountryId == countryId))
                .WithMessage("The provided Country Id does not exists.");
        }
    }
}
