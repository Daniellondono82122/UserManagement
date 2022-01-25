namespace UserManagement.Domain.Queries.StateQueries
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;
    public class GetAllStatesQuery : IRequest<ResponseDto<List<State>>>
    {
    }
}
