namespace UserManagement.Domain.Commands.UserCommands
{
    using Domain.Dtos;
    using MediatR;

    public class RegisterUserCommand : IRequest<ResponseDto<UserResponseDto>>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}
