using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA_Simulator_project.Data;
using NBA_Simulator_project.Models;

namespace NBA_Simulator_project.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class SeasonTeamController : ControllerBase {
        private readonly NbaDb _context;

        public SeasonTeamController(NbaDb context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<SeasonTeam>> GetSeasonTeam(int id) {
            var seasonTeam = await _context.SeasonTeams.FindAsync(id);

            if (seasonTeam == null) {
                return NotFound();
            }

            return seasonTeam;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SeasonTeam>> PutSeasonTeam(int id, SeasonTeam seasonTeam) {
            
            if (id != seasonTeam.SeasonTeamId) {
                return BadRequest();
            }

            _context.Entry(seasonTeam).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SeasonTeam>> PostSeasonTeam(SeasonTeam seasonTeam) {
            _context.SeasonTeams.Add(seasonTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeasonTeam", new { id = seasonTeam.SeasonTeamId }, seasonTeam);
        }
    }
}