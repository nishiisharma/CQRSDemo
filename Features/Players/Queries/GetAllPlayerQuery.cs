using System.Collections;
using CQRSPlayerDemo.Models;
using CQRSPlayerDemo.Services;
using MediatR;

namespace CQRSPlayerDemo.Features.Players.Queries
{
    public class GetAllPlayerQuery : IRequest<IEnumerable<Player>>
    {
        public class GetAllPlayerQueryHandler : IRequestHandler<GetAllPlayerQuery, IEnumerable<Player>>
        {
            private readonly IPlayerServices _playerServices;

            public GetAllPlayerQueryHandler(IPlayerServices playerServices)
            {
                _playerServices = playerServices;
            }
            public async Task<IEnumerable<Player>> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
            {
                return await _playerServices.GetPlayersList();
            }
        }
    }
}
