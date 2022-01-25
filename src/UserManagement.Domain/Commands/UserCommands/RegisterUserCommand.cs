namespace UserManagement.Domain.Commands.UserCommands
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;

    public class RegisterUserCommand : IRequest<ResponseDto<User>>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}
