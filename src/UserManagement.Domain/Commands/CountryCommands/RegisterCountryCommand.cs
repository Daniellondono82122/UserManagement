namespace UserManagement.Domain.Commands.CountryCommands
{
    using Domain.Dtos;
    using Domain.Model;
    using MediatR;

    public class RegisterCountryCommand : IRequest<ResponseDto<Country>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
