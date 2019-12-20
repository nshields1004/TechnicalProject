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
    public class PositionsController : ControllerBase
    {
        private readonly PositionsContext _context3;
        private readonly IDataRepository<playerpositions> _repo3;

        public PositionsController(PositionsContext context3, IDataRepository<playerpositions> repo3)
        {
            _context3 = context3;
            _repo3 = repo3;
        }

        // GET: api/Positions
        [HttpGet]
        public IEnumerable<playerpositions> GetPositions()
        {

            return _context3.playerpositions.OrderByDescending(ps => ps.id);

        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessions = await _context3.playerpositions.FindAsync(id);

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        // PUT: api/Positions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositions(int id, playerpositions positions)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != positions.id)
            {
                return BadRequest("id" + id + "is incorrect as it does not equal the session id of " + positions.id);
            }

            _context3.Entry(positions).State = EntityState.Modified;

            try
            {
                await _context3.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionsExists(id))
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


        // POST: api/Positions
        [HttpPost]
        public async Task<IActionResult> PostPositions([FromBody] playerpositions positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo3.Add(positions);
            var save = await _repo3.SaveAsync(positions);

            return CreatedAtAction("GetPositions", new { id = positions.id }, positions);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var positions = await _context3.playerpositions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }

            _repo3.Delete(positions);
            var save = await _repo3.SaveAsync(positions);

            return Ok(positions);
        }

        private bool PositionsExists(int id)
        {
            return _context3.playerpositions.Any(g => g.id == id);
        }
    }
}