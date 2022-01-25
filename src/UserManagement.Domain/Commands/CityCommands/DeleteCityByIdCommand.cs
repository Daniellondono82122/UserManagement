namespace UserManagement.Domain.Commands.CityCommands
{
    using Domain.Dtos;
    using MediatR;
    public class DeleteCityByIdCommand : IRequest<ResponseDto<bool>>
    {
        public int CityId { get; set; }
    }
}
