namespace UserManagement.Services.Validators.CommandValidators.CountryCommandValidators
{
    using Domain.Commands.CountryCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class DeleteCountryByIdCommandValidator : AbstractValidator<DeleteCountryByIdCommand>
    {
        public DeleteCountryByIdCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(preference => preference.CountryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (userId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<Country>(u => u.CountryId == userId))
                .WithMessage("The provided Country Id does not exists.");
        }
    }
}
