namespace UserManagement.Api.Controllers
{
    using Domain.Commands.StateCommands;
    using Domain.Queries.StateQueries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class StatesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("RegisterState")]
        public async Task<IActionResult> RegisterStateAsync([FromBody] RegisterStateCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("GetAllStates")]
        public async Task<IActionResult> GetAllStatesAsync()
        {
            var result = await _mediator.Send(new GetAllStatesQuery());
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpDelete]
        [Route("DeleteStateById")]
        public async Task<IActionResult> DeleteStateByIdAsync([FromBody] DeleteStateByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

    }
}
