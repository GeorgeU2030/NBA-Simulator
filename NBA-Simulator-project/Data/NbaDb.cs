using Microsoft.EntityFrameworkCore;
using NBA_Simulator_project.Models;

namespace NBA_Simulator_project.Data {
    public class NbaDb : DbContext {
        public NbaDb(DbContextOptions<NbaDb> options) : base(options) {
        }
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Season> Seasons => Set<Season>();
        public DbSet<SeasonTeam> SeasonTeams => Set<SeasonTeam>();
    }
}