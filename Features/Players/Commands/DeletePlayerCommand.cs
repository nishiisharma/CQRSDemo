using System.Reflection.Metadata.Ecma335;
using CQRSPlayerDemo.Services;
using MediatR;

namespace CQRSPlayerDemo.Features.Players.Commands
{
    public class DeletePlayerCommand :IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, int>
    {
        private readonly IPlayerServices _playerServices;

        public DeletePlayerCommandHandler(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }
        public async Task<int> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerServices.GetPlayerById(request.Id);

            return await _playerServices.DeletePlayer(player);
        }
       
    }
}
