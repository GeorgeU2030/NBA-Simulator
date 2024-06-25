namespace NBA_Simulator_project.Models {
    public class Serie {
        public int SerieId { get; set; }
        public int SeasonId { get; set; }
        public Season? Season { get; set; }
        public int? WinsHome { get; set; }
        public int? WinsVisitor { get; set; }
        public ICollection<Match> Matches { get; set; } = [];
        // 1: First Round, 2: Semifinals, 3: Conference Finals East,4: Conference Finals West, 5: NBA Finals
        public int? Phase { get; set; } 
    }
}