namespace UserManagement.Domain.Queries.CityQueries
{
    using MediatR;
    using Domain.Dtos;
    using Domain.Model;
    public class GetAllCitiesQuery : IRequest<ResponseDto<List<City>>>
    {
    }
}
