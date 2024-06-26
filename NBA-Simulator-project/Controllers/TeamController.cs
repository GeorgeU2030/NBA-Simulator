using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBA_Simulator_project.Data;
using NBA_Simulator_project.Models;

namespace NBA_Simulator_project.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase {

        private readonly NbaDb _context;

        public TeamController(NbaDb context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id) {
            var team = await _context.Teams.FindAsync(id);

            if (team == null) {
                return NotFound();
            }

            return team;
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<Team>> GetTeam(string name) {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Name == name);

            if (team == null) {
                return NotFound();
            }

            return team;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams() {
            return await _context.Teams.OrderByDescending(t => t.Rings).ToListAsync();
        }

        [HttpGet("editions")]
        public async Task<ActionResult<IEnumerable<object>>> GetTeamsWithChampionshipEditions() {
            var teamsWithChampionshipEditions = await _context.Teams
                .Where(team => team.Rings > 0)
                .Select(team => new {
                    Team = team,
                    ChampionshipEditions = _context.Seasons
                        .Where(season => season.ChampionId == team.TeamId)
                        .Select(season => season.Edition)
                        .OrderBy(edition => edition) 
                        .ToList(),
                    MostRecentEdition = _context.Seasons
                        .Where(season => season.ChampionId == team.TeamId)
                        .Max(season => season.Edition)
                })
                .OrderByDescending(teamWithChamps => teamWithChamps.Team.Rings)
                .ThenByDescending(teamWithChamps => teamWithChamps.MostRecentEdition)
                .ToListAsync();

            return teamsWithChampionshipEditions;
        }


        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team) {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        [HttpPut("{id}/division")]
        public async Task<ActionResult<Team>> UpdateDivision(int id) {
            var team = await _context.Teams.FindAsync(id);

            if (team == null) {
                return NotFound();
            }

            team.TitlesDivision += 1;

            await _context.SaveChangesAsync();

            return team;
        }

        [HttpPut("{id}/conference")]
        public async Task<ActionResult<Team>> UpdateConference(int id) {
            var team = await _context.Teams.FindAsync(id);

            if (team == null) {
                return NotFound();
            }

            team.TitlesConference += 1;

            await _context.SaveChangesAsync();

            return team;
        }

        [HttpPut("{id}/champion")]
        public async Task<ActionResult<Team>> UpdateChampionship(int id) {
            var team = await _context.Teams.FindAsync(id);

            if (team == null) {
                return NotFound();
            }

            team.Rings += 1;

            await _context.SaveChangesAsync();

            return team;
        }
        
    }
}