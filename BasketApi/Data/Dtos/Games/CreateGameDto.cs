namespace BasketApi.Data.Dtos.Games
{
    public class CreateGameDto
    {
        public DateTime Date { get; set; }
        public int AwayId { get; set; }
        public int HomeId { get; set; }
        public string? FinalScore { get; set; }
    }
}
