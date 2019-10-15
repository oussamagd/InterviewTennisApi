using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TennisApi.Business;
using TennisApi.Models;

namespace TennisApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayerBusiness _playerBusiness;
        public PlayersController(IPlayerBusiness playerBusiness)
        {
            _playerBusiness = playerBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return _playerBusiness.GetPlayers();
        }

        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _playerBusiness.GetPlayer(id);

            if (player != null)
            {
                return player;
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _playerBusiness.Delete(id);

            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
