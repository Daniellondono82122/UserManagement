namespace UserManagement.Domain.Queries.CountryQueries
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;
    public class GetAllCountriesQuery : IRequest<ResponseDto<List<Country>>>
    {
    }
}
