namespace UserManagement.Services.CommandHandlers.UserCommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using MediatR;
    using Domain.Commands.UserCommands;

    public class UserCommandHandlers
    {
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseDto<User>> 
        { 
            private readonly IDatabaseContext _context;
            public RegisterUserCommandHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<User>(); 
                List<SPParameter> parameters = new ()
                            {
                                new SPParameter { Name = "@Name", Value = request.Name, Type = TypeCode.String},
                                new SPParameter { Name = "@PhoneNumber", Value = request.PhoneNumber, Type = TypeCode.String},
                                new SPParameter { Name = "@Address", Value = request.Address, Type = TypeCode.String},
                                new SPParameter { Name = "@CityId", Value = request.CityId, Type = TypeCode.Int32 }
                            };
                var res = await _context.Users.ExecuteSPAsync("dbo.PostUser", cancellationToken, parameters);
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
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, ResponseDto<bool>>
        {
            private readonly IDatabaseContext _context;
            public DeleteUserByIdCommandHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<bool>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<bool>();
                List<SPParameter> parameters = new()
                {
                    new SPParameter { Name = "@UserId", Value = request.UserId, Type = TypeCode.Int32 }
                };
                var res = await _context.Users.ExecuteSPAsync("dbo.DeleteUserById", cancellationToken, parameters);
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
