using Microsoft.AspNetCore.Mvc;
using NBA_Simulator_project.Data;
using NBA_Simulator_project.Models;

namespace NBA_Simulator_project.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase {
        private readonly NbaDb _context;

        public MatchController(NbaDb context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Match>> GetMatch(int id) {
            var match = await _context.Matches.FindAsync(id);

            if (match == null) {
                return NotFound();
            }

            return match;
        }

        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match) {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.MatchId }, match);
        }
    }
}