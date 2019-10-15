using System.Collections.Generic;
using TennisApi.Models;

namespace TennisApi.Business
{
    public interface IPlayerBusiness
    {
        List<Player> GetPlayers();
        Player GetPlayer(int id);
        bool Delete(int id);
    }
}
