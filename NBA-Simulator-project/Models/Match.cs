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
        // 1: First Round, 2: Semifinals, 3: Conference Finals East,4: Conference Finals West, 5: NBA Finals
        public int? Phase { get; set; } 
    }
}