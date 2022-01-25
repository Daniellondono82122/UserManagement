namespace UserManagement.Domain.Queries.StateQueries
{
    using MediatR;
    using Domain.Dtos;
    using Domain.Model;
    public class GetAllStatesQuery : IRequest<ResponseDto<List<State>>>
    {
    }
}
