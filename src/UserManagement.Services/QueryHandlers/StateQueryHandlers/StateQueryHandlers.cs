namespace UserManagement.Services.QueryHandlers.StateQueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data.Extensions;
    using Domain.Dtos;
    using Domain.Interfaces.Data;
    using Domain.Model;
    using Domain.Queries.StateQueries;
    using MediatR;

    public class StateQueryHandlers
    {
        public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, ResponseDto<List<State>>>
        {
            private readonly IDatabaseContext _context;
            public GetAllStatesQueryHandler(IDatabaseContext databaseContext)
            {
                _context = databaseContext;
            }

            public async Task<ResponseDto<List<State>>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
            {
                var response = new ResponseDto<List<State>>();
                response.Result = await _context.States.ExecuteSPAsync("dbo.GetStates", cancellationToken);
                return response;
            }
        }
    }
}
