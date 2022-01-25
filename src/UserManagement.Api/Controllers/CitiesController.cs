namespace UserManagement.Api.Controllers
{
    using Domain.Commands.CityCommands;
    using Domain.Queries.CityQueries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitiesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("RegisterCity")]
        public async Task<IActionResult> RegisterCityAsync([FromBody] RegisterCityCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("GetAllCities")]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var result = await _mediator.Send(new GetAllCitiesQuery());
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpDelete]
        [Route("DeleteCityById")]
        public async Task<IActionResult> DeleteCityByIdAsync([FromBody] DeleteCityByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

    }
}
