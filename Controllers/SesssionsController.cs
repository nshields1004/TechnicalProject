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
    public class SessionsController : ControllerBase
    {
        private readonly SessionsContext _context2;
        private readonly IDataRepository<Sessions> _repo2;

        public SessionsController(SessionsContext context2, IDataRepository<Sessions> repo2)
        {
            _context2 = context2;
            _repo2 = repo2;
        }

        // GET: api/Sessions
        [HttpGet]
        public IEnumerable<Sessions> GetSessions()
        {

            return _context2.Sessions.OrderByDescending(s => s.id);

        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessions = await _context2.Sessions.FindAsync(id);

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        // PUT: api/Sessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessions(int id, Sessions sessions)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessions.id)
            {
                return BadRequest("id" + id + "is incorrect as it does not equal the session id of " + sessions.id);
            }

            _context2.Entry(sessions).State = EntityState.Modified;

            try
            {
                await _context2.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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


        // POST: api/Sessions
        [HttpPost]
        public async Task<IActionResult> PostSession([FromBody] Sessions sessions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo2.Add(sessions);
            var save = await _repo2.SaveAsync(sessions);

            return CreatedAtAction("GetSessions", new { id = sessions.id }, sessions);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessions = await _context2.Sessions.FindAsync(id);
            if (sessions == null)
            {
                return NotFound();
            }

            _repo2.Delete(sessions);
            var save = await _repo2.SaveAsync(sessions);

            return Ok(sessions);
        }

        private bool SessionExists(int id)
        {
            return _context2.Sessions.Any(f => f.id == id);
        }
    }
}