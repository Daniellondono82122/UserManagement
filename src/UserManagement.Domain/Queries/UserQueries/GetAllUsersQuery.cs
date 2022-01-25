namespace UserManagement.Domain.Queries.UserQueries
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;
    public class GetAllUsersQuery : IRequest<ResponseDto<List<UserResponseDto>>>
    {
    }
}
