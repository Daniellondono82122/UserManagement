namespace UserManagement.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Domain.Queries.UserQueries;
    using Domain.Commands.UserCommands;

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpDelete]
        [Route("DeleteUserById")]
        public async Task<IActionResult> DeleteUserByIdAsync([FromBody] DeleteUserByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

    }
}
