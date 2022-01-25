namespace UserManagement.Services.QueryHandlers.CityQueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using Domain.Queries.CityQueries;
    using MediatR;

    public class CityQueryHandlers
    {
        public class GetAllCitysQueryHandler : IRequestHandler<GetAllCitiesQuery, ResponseDto<List<City>>>
        {
            private readonly IDatabaseContext _context;
            public GetAllCitysQueryHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<List<City>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<List<City>>();
                response.Result = await _context.Cities.ExecuteSPAsync("dbo.GetCities", cancellationToken);
                return response;
            }
        }
    }
}
