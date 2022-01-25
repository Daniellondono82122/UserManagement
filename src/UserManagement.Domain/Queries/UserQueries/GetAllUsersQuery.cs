namespace UserManagement.Domain.Queries.UserQueries
{
    using MediatR;
    using Domain.Dtos;
    using Domain.Model;
    public class GetAllUsersQuery : IRequest<ResponseDto<List<User>>>
    {
    }
}
