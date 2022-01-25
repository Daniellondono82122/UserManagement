namespace UserManagement.Domain.Queries.CityQueries
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;
    public class GetAllCitiesQuery : IRequest<ResponseDto<List<City>>>
    {
    }
}
