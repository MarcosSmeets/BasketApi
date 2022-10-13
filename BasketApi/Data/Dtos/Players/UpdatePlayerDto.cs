namespace BasketApi.Data.Dtos.Players
{
    public class UpdatePlayerDto
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string? Height { get; set; }
        public int YearsPro { get; set; }
        public string? PlayerPicture { get; set; }
        public int JarseyNumber { get; set; }
        public int TeamId { get; set; }
        public int PossitionId { get; set; }
        public int CountryId { get; set; }
    }
}
