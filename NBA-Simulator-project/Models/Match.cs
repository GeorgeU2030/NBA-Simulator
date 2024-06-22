namespace NBA_Simulator_project.Models {
    public class Match {
        public int MatchId { get; set; }
        public required int SeasonId { get; set; }
        public Season? Season { get; set; }
        public required int HomeTeamId { get; set; }
        public Team? HomeTeam { get; set; }
        public required int VisitorTeamId { get; set; }
        public Team? VisitorTeam { get; set; }
        public int HomeScore { get; set; }
        public int VisitorScore { get; set; }

    }
}