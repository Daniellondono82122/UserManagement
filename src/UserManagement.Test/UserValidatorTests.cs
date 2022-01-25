namespace UserManagement.Test
{
    using System.Threading.Tasks;
    using AutoFixture;
    using Domain.Commands.UserCommands;
    using Domain.Interfaces.Services;
    using FluentValidation.TestHelper;
    using NSubstitute;
    using Services.Validators.CommandValidators.UserCommandValidators;
    using Xunit;
    using Xunit.Categories;

    public class UserValidatorTests
    {
        private RegisterUserCommandValidator _registerUserCommandValidator;
        private readonly ICommonValidators _commonValidator;
        public Fixture _fixture;

        public UserValidatorTests()
        {
            _commonValidator = Substitute.For<ICommonValidators>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _registerUserCommandValidator = new RegisterUserCommandValidator(_commonValidator);
        }

        [Fact]
        [UnitTest("RegisterUserWrongData")]
        public async Task RegisterUserCommandHandler_RegisterUser_Wrong_CityId()
        {
            var command = _fixture.Create<RegisterUserCommand>();
            var result = await _registerUserCommandValidator.TestValidateAsync(command);
            result.ShouldHaveValidationErrorFor(r => r.CityId);
        }

    }
}
