namespace NBA_Simulator_project.Models {

    public class Season {
        public int SeasonId { get; set; }
        public int Edition { get; set; }
        public int? ChampionId { get; set; }
        public Team? Champion { get; set; }
        public int? SubChampionId { get; set; }
        public Team? SubChampion { get; set; }
        public int? ChampionEastId { get; set; }
        public Team? ChampionEast { get; set; }
        public int? ChampionWestId { get; set; }
        public Team? ChampionWest { get; set; }
        public int? SemiFinalistEastId { get; set; }
        public Team? SemiFinalistEast { get; set; }
        public int? SemiFinalistWestId { get; set; }
        public Team? SemiFinalistWest { get; set; }
        public ICollection<SeasonTeam> Teams { get; set; } = [];
        public ICollection<Serie> Series { get; set; } = [];


    }
}