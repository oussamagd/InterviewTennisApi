using System.Collections.Generic;
using TennisApi.Models;

namespace TennisApi.Repositories
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayers();
    }
}
