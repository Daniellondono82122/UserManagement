namespace UserManagement.Services.QueryHandlers.UserQueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Queries.UserQueries;
    using MediatR;

    public class UserQueryHandlers
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseDto<List<UserResponseDto>>>
        {
            private readonly IDatabaseContext _context;
            public GetAllUsersQueryHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<List<UserResponseDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<List<UserResponseDto>>();
                response.Result = await _context.UserResponseDto.ExecuteSPAsync("dbo.GetUsers", cancellationToken);
                return response;
            }
        }
    }
}
