using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatSportsTechnicalProject.Data;
using StatSportsTechnicalProject.Models;

namespace StatSportsTechnicalProject.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersContext _context;
        private readonly IDataRepository<Players> _repo;

        public PlayersController(PlayersContext context, IDataRepository<Players> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Players
        [HttpGet]
        public IEnumerable<Players> GetPlayers()
        {

            return _context.Players.OrderByDescending(p => p.id);

        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var players = await _context.Players.FindAsync(id);

            if (players == null)
            {
                return NotFound();
            }

            return Ok(players);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayers(int id, Players players)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != players.id)
            {
                return BadRequest("id" + id + "is incorrect as it does not equal the players id of " + players.id);
            }

            _context.Entry(players).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Players players)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(players);
            var save = await _repo.SaveAsync(players);

            return CreatedAtAction("GetPlayers", new { id = players.id }, players);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _repo.Delete(player);
            var save = await _repo.SaveAsync(player);

            return Ok(player);
        }

        private bool PlayersExists(int id)
        {
            return _context.Players.Any(e => e.id == id);
        }
    }
}