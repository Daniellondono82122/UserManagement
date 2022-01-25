namespace UserManagement.Domain.Queries.CountryQueries
{
    using MediatR;
    using Domain.Dtos;
    using Domain.Model;
    public class GetAllCountriesQuery : IRequest<ResponseDto<List<Country>>>
    {
    }
}
