using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<Season>> GetSeason(int id) {
            var season = await _context.Seasons.FindAsync(id);

            if (season == null) {
                return NotFound();
            }

            return season;
        }

        [HttpPost]
        public async Task<ActionResult<Season>> PostSeason(Season season) {
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeason", new { id = season.SeasonId }, season);
        }
    }
}