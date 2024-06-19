using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA_Simulator_project.Data;
using NBA_Simulator_project.Models;

namespace NBA_Simulator_project.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase {
        private readonly NbaDb _context;

        public SeasonController(NbaDb context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Season>> GetSeason(int id) {
            var season = await _context.Seasons
                .Include(s => s.Teams)
                .FirstOrDefaultAsync(s => s.SeasonId == id);

            if (season == null) {
                return NotFound();
            }

            return season;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetSeasons() {
            return await _context.Seasons.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Season>> PostSeason(Season season) {
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeason", new { id = season.SeasonId }, season);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AddTeamToSeason(int id, SeasonTeam seasonTeam) {
            var season = await _context.Seasons.FindAsync(id);

            if (season == null) {
                return NotFound();
            }

            season.Teams.Add(seasonTeam);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}