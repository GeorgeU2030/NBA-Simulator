namespace NBA_Simulator_project.Models {
    public class SeasonTeam {
        public int SeasonTeamId { get; set; }
        public int SeasonId { get; set; }
        public required Season Season { get; set; }
        public required string Name { get; set; }
        public required string Logo { get; set; }
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int Percentage { get; set; } = 0;
    }
}