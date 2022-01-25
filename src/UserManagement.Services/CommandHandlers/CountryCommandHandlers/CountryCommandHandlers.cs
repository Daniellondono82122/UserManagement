namespace UserManagement.Services.CommandHandlers.CountryCommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using MediatR;
    using Domain.Commands.CountryCommands;

    public class CountryCommandHandlers
    {
        public class RegisterCountryCommandHandler : IRequestHandler<RegisterCountryCommand, ResponseDto<Country>>
        {
            private readonly IDatabaseContext _context;
            public RegisterCountryCommandHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<Country>> Handle(RegisterCountryCommand request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<Country>();
                List<SPParameter> parameters = new()
                {
                    new SPParameter { Name = "@Name", Value = request.Name, Type = TypeCode.String },
                    new SPParameter { Name = "@Code", Value = request.Code, Type = TypeCode.String }
                };
                var res = await _context.Countries.ExecuteSPAsync("dbo.PostCountry", cancellationToken, parameters);
                if (res.Any())
                {
                    response.Message = "Added Succesfully";
                    response.Result = res.First();
                }
                else
                {
                    response.Message = "Error Inserting..";
                }

                return response;
            }
        }
        public class DeleteCountryByIdCommandHandler : IRequestHandler<DeleteCountryByIdCommand, ResponseDto<bool>>
        {
            private readonly IDatabaseContext _context;
            public DeleteCountryByIdCommandHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<bool>> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<bool>();
                List<SPParameter> parameters = new()
                {
                    new SPParameter { Name = "@CountryId", Value = request.CountryId, Type = TypeCode.Int32 }
                };
                var res = await _context.Cities.ExecuteSPAsync("dbo.DeleteCountryById", cancellationToken, parameters);
                if (!res.Any())
                {
                    response.Message = "Deleted Succesfully";
                    response.Result = true;
                }
                else
                {
                    response.Message = "Error Deleting..";
                    response.Result = false;
                }

                return response;
            }
        }
    }
}
