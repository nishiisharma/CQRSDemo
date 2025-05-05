using CQRSPlayerDemo.Models;
using CQRSPlayerDemo.Services;
using MediatR;

namespace CQRSPlayerDemo.Features.Players.Commands
{
    public class UpdatePlayerCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public int? ShirtNo { get; set; }
        public string Name { get; set; }

        public int? Appearance { get; set; }

        public int? Goals { get; set; }
    }

    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, int>
    {
        private readonly IPlayerServices _playerServices;

        public UpdatePlayerCommandHandler(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }
        public async Task<int> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                Id = request.Id,
                ShirtNo = request.ShirtNo,
                Name = request.Name,
                Appearance = request.Appearance,
                Goals = request.Goals
            };
           return await _playerServices.UpdatePlayer(player);
        }
    }
}
