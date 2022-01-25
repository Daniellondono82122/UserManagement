namespace UserManagement.Services.Validators.CommandValidators.CityCommandValidators
{
    using Domain.Commands.CityCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class RegisterCityCommandValidator : AbstractValidator<RegisterCityCommand>
    {
        public RegisterCityCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("City Name has cannot be empty");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Code has cannot be empty");

            RuleFor(preference => preference.StateId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (stateId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<State>(u => u.StateId == stateId))
                .WithMessage("The provided State Id does not exists.");
        }
    }
}
