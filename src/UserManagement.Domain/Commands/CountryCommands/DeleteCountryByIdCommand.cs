namespace UserManagement.Domain.Commands.CountryCommands
{
    using Domain.Dtos;
    using MediatR;
    public class DeleteCountryByIdCommand : IRequest<ResponseDto<bool>>
    {
        public int CountryId { get; set; }
    }
}
