namespace UserManagement.Services.Validators.CommandValidators.StateCommandValidators
{
    using Domain.Commands.StateCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class DeleteStateByIdCommandValidator : AbstractValidator<DeleteStateByIdCommand>
    {
        public DeleteStateByIdCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(preference => preference.StateId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (userId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<State>(u => u.StateId == userId))
                .WithMessage("The provided State Id does not exists.");
        }
    }
}
