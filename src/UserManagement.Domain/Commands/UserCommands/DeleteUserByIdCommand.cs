namespace UserManagement.Domain.Commands.UserCommands
{
    using Domain.Dtos;
    using MediatR;
    public class DeleteUserByIdCommand : IRequest<ResponseDto<bool>>
    {
        public int UserId { get; set; }
    }
}
