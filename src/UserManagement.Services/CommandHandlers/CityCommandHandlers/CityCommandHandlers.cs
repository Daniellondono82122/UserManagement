namespace UserManagement.Services.CommandHandlers.CityCommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using MediatR;
    using Domain.Commands.CityCommands;

    public class CityCommandHandlers
    {
        public class RegisterCityCommandHandler : IRequestHandler<RegisterCityCommand, ResponseDto<City>>
        {
            private readonly IDatabaseContext _context;
            public RegisterCityCommandHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<City>> Handle(RegisterCityCommand request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<City>();
                List<SPParameter> parameters = new()
                {
                    new SPParameter { Name = "@Name", Value = request.Name, Type = TypeCode.String },
                    new SPParameter { Name = "@Code", Value = request.Code, Type = TypeCode.String },
                    new SPParameter { Name = "@StateId", Value = request.StateId, Type = TypeCode.Int32 }
                };
                var res = await _context.Cities.ExecuteSPAsync("dbo.PostCity", cancellationToken, parameters);
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
        public class DeleteCityByIdCommandHandler : IRequestHandler<DeleteCityByIdCommand, ResponseDto<bool>>
        {
            private readonly IDatabaseContext _context;
            public DeleteCityByIdCommandHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<bool>> Handle(DeleteCityByIdCommand request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<bool>();
                List<SPParameter> parameters = new()
                {
                    new SPParameter { Name = "@CityId", Value = request.CityId, Type = TypeCode.Int32 }
                };
                var res = await _context.Cities.ExecuteSPAsync("dbo.DeleteCityById", cancellationToken, parameters);
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
