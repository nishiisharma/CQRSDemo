using CQRSPlayerDemo.Models;
using CQRSPlayerDemo.Services;
using MediatR;

namespace CQRSPlayerDemo.Features.Players.Commands
{
    public class CreatePlayerCommand : IRequest<Player>
    {
        public int? ShirtNo { get; set; }
        public string Name { get; set; }

        public int? Appearance { get; set; }

        public int? Goals { get; set; }
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand,Player>
    {
        private readonly IPlayerServices _playerServices;
        public CreatePlayerCommandHandler(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }
        public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                Name = request.Name,
                ShirtNo = request.ShirtNo,
                Appearance = request.Appearance,
                Goals = request.Goals
            };

           return await _playerServices.CreatePlayer(player);
        }
    }
}
