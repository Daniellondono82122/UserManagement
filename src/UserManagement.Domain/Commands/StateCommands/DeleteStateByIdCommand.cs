namespace UserManagement.Domain.Commands.StateCommands
{
    using Domain.Dtos;
    using MediatR;
    public class DeleteStateByIdCommand : IRequest<ResponseDto<bool>>
    {
        public int StateId { get; set; }
    }
}
