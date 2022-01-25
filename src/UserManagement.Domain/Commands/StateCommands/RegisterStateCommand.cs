namespace UserManagement.Domain.Commands.StateCommands
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;

    public class RegisterStateCommand : IRequest<ResponseDto<State>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
