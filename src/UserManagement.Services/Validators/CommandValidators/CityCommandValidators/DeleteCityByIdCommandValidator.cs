namespace UserManagement.Services.Validators.CommandValidators.CityCommandValidators
{
    using Domain.Commands.CityCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class DeleteCityByIdCommandValidator : AbstractValidator<DeleteCityByIdCommand>
    {
        public DeleteCityByIdCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(preference => preference.CityId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (userId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<City>(u => u.CityId == userId))
                .WithMessage("The provided City Id does not exists.");
        }
    }
}
