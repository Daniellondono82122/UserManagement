namespace UserManagement.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Domain.Commands.CountryCommands;
    using Domain.Queries.CountryQueries;

    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("RegisterCountry")]
        public async Task<IActionResult> RegisterCountryAsync([FromBody] RegisterCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpGet]
        [Route("GetAllCountries")]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var result = await _mediator.Send(new GetAllCountriesQuery());
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpDelete]
        [Route("DeleteCountryById")]
        public async Task<IActionResult> DeleteCountryByIdAsync([FromBody] DeleteCountryByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Errors is null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

    }
}
