using CQRSPlayerDemo.Models;

namespace CQRSPlayerDemo.Services
{
    public interface IPlayerServices
    {
        Task<IEnumerable<Player>> GetPlayersList();
        Task<Player> GetPlayerById(int  id);
        Task<Player> CreatePlayer(Player player);
        Task<int> DeletePlayer(Player player);

        Task<int> UpdatePlayer(Player player);
    }
}
