namespace UserManagement.Services.QueryHandlers.UserQueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using Domain.Queries.UserQueries;
    using MediatR;

    public class UserQueryHandlers
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseDto<List<User>>>
        {
            private readonly IDatabaseContext _context;
            public GetAllUsersQueryHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<List<User>>();
                response.Result = await _context.Users.ExecuteSPAsync("dbo.GetUsers", cancellationToken);
                return response;
            }
        }
    }
}
