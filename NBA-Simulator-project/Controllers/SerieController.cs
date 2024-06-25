using Microsoft.AspNetCore.Mvc;
using NBA_Simulator_project.Data;
using NBA_Simulator_project.Models;

namespace NBA_Simulator_project.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase {
        private readonly NbaDb _context;

        public SerieController(NbaDb context) {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerie(int id) {
            var serie = await _context.Series.FindAsync(id);

            if (serie == null) {
                return NotFound();
            }

            return serie;
        }

        [HttpPost]
        public async Task<ActionResult<Serie>> PostSerie(Serie serie) {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.SerieId }, serie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Serie>> UpdateWins(int id, int winshome, int winsaway) {
            var serie = await _context.Series.FindAsync(id);

            if (serie == null) {
                return NotFound();
            }

            serie.WinsHome = winshome;
            serie.WinsVisitor = winsaway;

            await _context.SaveChangesAsync();

            return serie;
        }

    }

}