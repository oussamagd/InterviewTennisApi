using System;
using System.Collections.Generic;
using System.Text;
using TennisApi.Business;
using TennisApi.Models;

namespace TennisApiTest.Controllers
{
    class PlayerBusinessMock : IPlayerBusiness
    {
        public bool Delete(int id)
        {
            return id == 1 || id == 2;
        }

        public Player GetPlayer(int id)
        {
            if (id == 1)
            {
                return new Player()
                {
                    FirstName = "Roger",
                    LastName = "Federer",
                    Id = 1,
                    ShortName = "Roger",
                    Country = new Country() { Code = "ch", Picture = "suisse.png" },
                    Sex = Sex.M,
                    Data = new PlayerData()
                    {
                        Age = 84,
                        Height = 185,
                        Rank = 3,
                        Weights = 80,
                        Points = 500,
                        Last = new int[] { 3, 3, 3, 3, 3 }
                    }
                };
            }
            if (id == 2)
            {
                return new Player()
                {
                    FirstName = "Novak",
                    LastName = "Djokovic"
                };
            }
            return null;
        }

        public List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player()
                {
                    FirstName = "Roger",
                    LastName = "Federer",
                    Id = 1,
                    ShortName = "Roger",
                    Country = new Country() { Code = "ch", Picture = "suisse.png" },
                    Sex = Sex.M,
                    Data = new PlayerData()
                    {
                        Age = 84,
                        Height = 185,
                        Rank = 3,
                        Weights = 80,
                        Points = 500,
                        Last = new int[] { 3, 3, 3, 3, 3 }
                    }
                },
                new Player()
                {
                    FirstName = "Novak",
                    LastName = "Djokovic"
                }
            };
        }
    }
}
