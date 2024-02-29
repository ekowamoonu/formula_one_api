namespace FormulaOne.Entities.Dtos.Responses
{
    public class CreateDriverAchievementResponse
    {
        public Guid DriverId { get; set; }
        public int WorldChampionship { get; set; }
        public int FastestLap { get; set; }
        public int PolePosition { get; set; }
        public int Wins { get; set; }
    }
}