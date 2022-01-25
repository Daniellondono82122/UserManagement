namespace UserManagement.Services.Validators.CommandValidators.UserCommandValidators
{
    using Domain.Commands.UserCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("User Name has cannot be empty");
            RuleFor(p => p.Address).NotEmpty().WithMessage("Address has cannot be empty");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("PhoneNumber has cannot be empty");

            RuleFor(preference => preference.CityId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (cityId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<City>(u => u.CityId == cityId))
                .WithMessage("The provided City Id does not exists.");
        }
    }
}
