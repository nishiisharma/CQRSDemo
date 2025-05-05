using CQRSPlayerDemo.Models;
using CQRSPlayerDemo.Services;
using MediatR;

namespace CQRSPlayerDemo.Features.Players.Queries
{
    public class GetPlayersWithPaginationQuery : IRequest<GetPlayersWithPaginationResult>
    {
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }

    public class GetPlayersWithPaginationResult
    {
        public IEnumerable<Player> Players { get; set; } = new List<Player>();
        public int TotalCount { get; set; }
    }

    public class GetPlayersWithPaginationHandler : IRequestHandler<GetPlayersWithPaginationQuery, GetPlayersWithPaginationResult>
    {
        private readonly IPlayerServices _playerServices;

        public GetPlayersWithPaginationHandler(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }

        public async Task<GetPlayersWithPaginationResult> Handle(GetPlayersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var allPlayers = await _playerServices.GetPlayersList();

            var filtered = allPlayers
                .Where(p => string.IsNullOrEmpty(request.SearchTerm)
                    || (p.Name != null && p.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase))
                    || (p.ShirtNo.HasValue && p.ShirtNo.ToString()!.Contains(request.SearchTerm)))
                .ToList();

            var total = filtered.Count;

            var paginated = filtered
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new GetPlayersWithPaginationResult
            {
                Players = paginated,
                TotalCount = total
            };
        }
    }
}
