namespace UserManagement.Services.QueryHandlers.CountryQueryHandlers
{

    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using Domain.Queries.CountryQueries;
    using MediatR;

    public class CountryQueryHandlers
    {
        public class GetAllCountrysQueryHandler : IRequestHandler<GetAllCountriesQuery, ResponseDto<List<Country>>>
        {
            private readonly IDatabaseContext _context;
            public GetAllCountrysQueryHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<List<Country>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<List<Country>>();
                response.Result = await _context.Countries.ExecuteSPAsync("dbo.GetCountries", cancellationToken);
                return response;
            }
        }
    }
}
