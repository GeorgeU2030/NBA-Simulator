namespace NBA_Simulator_project.Models {
    public class Team
    {
        public int TeamId { get; set; }
        public required string Name { get; set; }
        public required string Logo { get; set; }
        public required string Conference { get; set; }
        public required string Division { get; set; }
        public int Rings { get; set; } = 0;
        public int TitlesConference { get; set; } = 0;
        public int TitlesDivision { get; set; } = 0;

    }
}