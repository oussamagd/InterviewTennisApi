using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TennisApi.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ShortName { get; set; }

        public Sex Sex { get; set; }

        public Country Country { get; set; }

        public PlayerData Data { get; set; }
    }
}
