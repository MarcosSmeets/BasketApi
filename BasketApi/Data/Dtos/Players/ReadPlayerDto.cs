using BasketApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BasketApi.Data.Dtos.Players
{
    public class ReadPlayerDto
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string? Height { get; set; }
        public int YearsPro { get; set; }
        public string? PlayerPicture { get; set; }
        [Required]
        public int JarseyNumber { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public int PossitionId { get; set; }
        public Possition? Possition { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
