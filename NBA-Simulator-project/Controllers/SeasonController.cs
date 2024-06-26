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
                .Include(s => s.Series)
                .ThenInclude(m => m.Matches)
                .ThenInclude(n => n.HomeTeam)
                .Include(s => s.Series)
                .ThenInclude(m => m.Matches)
                .ThenInclude(n => n.VisitorTeam)
                .FirstOrDefaultAsync(s => s.SeasonId == id);

            if (season == null) {
                return NotFound();
            }

            return season;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetSeasons() {
            
            var seasons = await _context.Seasons
                .Include(s => s.Champion)
                .Include(s => s.SubChampion)
                .Include(s => s.SemiFinalistEast)
                .Include(s => s.SemiFinalistWest)
                .OrderByDescending(s => s.SeasonId)
                .ToListAsync();

            return seasons;
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

        [HttpPost("{seasonId}/chEast")]
        public async Task<IActionResult> AddChampionsEast(int seasonId, int championEastId, int semiFinalistEastId)
        {
            var season = await _context.Seasons.FindAsync(seasonId);
            if (season == null)
            {
                return NotFound($"Season with ID {seasonId} not found.");
            }

            var championEastTeam = await _context.Teams.FindAsync(championEastId);
            if (championEastTeam == null)
            {
                return NotFound($"Team with ID {championEastId} not found.");
            }

            var semiFinalistEastTeam = await _context.Teams.FindAsync(semiFinalistEastId);
            if (semiFinalistEastTeam == null)
            {
                return NotFound($"Team with ID {semiFinalistEastId} not found.");
            }

            season.ChampionEast = championEastTeam;
            season.ChampionEastId = championEastId;
            season.SemiFinalistEast = semiFinalistEastTeam;
            season.SemiFinalistEastId = semiFinalistEastId;

            await _context.SaveChangesAsync();

            return Ok($"Champion East and SemiFinalist East have been updated for Season {seasonId}.");
        }


        [HttpPost("{seasonId}/chWest")]
        public async Task<IActionResult> AddChampionsWest(int seasonId, int championWestId, int semiFinalistWestId)
        {
            var season = await _context.Seasons.FindAsync(seasonId);
            if (season == null)
            {
                return NotFound($"Season with ID {seasonId} not found.");
            }

            var championWestTeam = await _context.Teams.FindAsync(championWestId);
            if (championWestTeam == null)
            {
                return NotFound($"Team with ID {championWestId} not found.");
            }

            var semiFinalistWestTeam = await _context.Teams.FindAsync(semiFinalistWestId);
            if (semiFinalistWestTeam == null)
            {
                return NotFound($"Team with ID {semiFinalistWestId} not found.");
            }

            season.ChampionWest = championWestTeam;
            season.ChampionWestId = championWestId;
            season.SemiFinalistWest = semiFinalistWestTeam;
            season.SemiFinalistWestId = semiFinalistWestId;

            await _context.SaveChangesAsync();

            return Ok($"Champion East and SemiFinalist West have been updated for Season {seasonId}.");
        }

        [HttpPost("{seasonId}/champion")]
        public async Task<IActionResult> AddChampion(int seasonId, int championId, int subChampionId)
        {
            var season = await _context.Seasons.FindAsync(seasonId);
            if (season == null)
            {
                return NotFound($"Season with ID {seasonId} not found.");
            }

            var championTeam = await _context.Teams.FindAsync(championId);
            if (championTeam == null)
            {
                return NotFound($"Team with ID {championId} not found.");
            }

            var semiFinalistTeam = await _context.Teams.FindAsync(subChampionId);
            if (semiFinalistTeam == null)
            {
                return NotFound($"Team with ID {subChampionId} not found.");
            }

            season.Champion = championTeam;
            season.ChampionId = championId;
            season.SubChampion = semiFinalistTeam;
            season.SubChampionId = subChampionId;

            await _context.SaveChangesAsync();

            return Ok($"Champion and SemiFinalist have been updated for Season {seasonId}.");
        }
    }
}