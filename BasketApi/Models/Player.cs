using System.ComponentModel.DataAnnotations;

namespace BasketApi.Models
{
    public class Player
    {
        [Key]
        [Required]
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
        public virtual Team? Team { get; set; }
        public int TeamId { get; set; }
        public virtual Possition? Possition { get; set; }
        public int PossitionId { get; set; }
        public virtual Country? Country { get; set; }
        public int CountryId { get; set; }
    }
}
