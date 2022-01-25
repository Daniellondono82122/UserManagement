namespace UserManagement.Services.Validators.CommandValidators.CountryCommandValidators
{
    using Domain.Commands.CountryCommands;
    using FluentValidation;

    public class RegisterCountryCommandValidator : AbstractValidator<RegisterCountryCommand>
    {
        public RegisterCountryCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Country Name has cannot be empty");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Code has cannot be empty");
        }
    }
}
