using CQRSPlayerDemo.Models;
using CQRSPlayerDemo.Services;
using MediatR;

namespace CQRSPlayerDemo.Features.Players.Queries
{
    public class GetPlayerByIdQuery : IRequest<Player>
    {
        public int Id { get; set; }
    }

    public class GetPlayerIdQuery : IRequestHandler<GetPlayerByIdQuery, Player>
    {  

        private readonly IPlayerServices _playerServices;

        public GetPlayerIdQuery(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }
        public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
           return await _playerServices.GetPlayerById(request.Id);
        }
    }
}
