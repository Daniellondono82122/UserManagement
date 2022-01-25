namespace UserManagement.Services.Validators.CommandValidators.UserCommandValidators
{
    using Domain.Commands.UserCommands;
    using Domain.Interfaces.Services;
    using Domain.Model;
    using FluentValidation;

    public class DeleteUserByIdCommandValidator : AbstractValidator<DeleteUserByIdCommand>
    {
        public DeleteUserByIdCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(preference => preference.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(async (userId, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<User>(u => u.UserId == userId))
                .WithMessage("The provided User Id does not exists.");
        }
    }
}
