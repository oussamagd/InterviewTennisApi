using System.Collections.Generic;
using System.Linq;
using TennisApi.Models;
using TennisApi.Repositories;

namespace TennisApi.Business
{
    public class PlayerBusiness : IPlayerBusiness
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerBusiness(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool Delete(int id)
        {
            var playerTodelete = _playerRepository.GetPlayers().Find(player => player.Id == id);
            if (playerTodelete == null)
            {
                return false;
            }
            // code for deleting
            return true;
        }

        public Player GetPlayer(int id)
        {
            return _playerRepository.GetPlayers().Find(player => player.Id == id);
        }

        public List<Player> GetPlayers()
        {
            return _playerRepository.GetPlayers().OrderBy(player => player.Id).ToList();
        }
    }
}
