using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using TennisApi.Models;

namespace TennisApi.Repositories.Htttp
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApiConfiguration _apiConfiguration;
        private readonly IMemoryCache _cache;

        public PlayerRepository(IOptions<ApiConfiguration> apiConfiguration, IMemoryCache memoryCache)
        {
            _apiConfiguration = apiConfiguration.Value;
            _cache = memoryCache;
        }
        public List<Player> GetPlayers()
        {
            List<Player> players;
            if (!_cache.TryGetValue("Players", out players))
            {
                players = HttpHelper.Get<PlayersHttpObject>(_apiConfiguration.GetPlayersUrl).Players ?? new List<Player>();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
                _cache.Set("Players", players, cacheEntryOptions);
            }

            return players;
        }
    }
}
