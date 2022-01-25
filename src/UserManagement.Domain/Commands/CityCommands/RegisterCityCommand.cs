namespace UserManagement.Domain.Commands.CityCommands
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;

    public class RegisterCityCommand : IRequest<ResponseDto<City>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}
