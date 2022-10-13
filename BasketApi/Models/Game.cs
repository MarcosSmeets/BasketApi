using System.ComponentModel.DataAnnotations;

namespace BasketApi.Models
{
    public class Game
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual Team? Away { get; set; }
        public int AwayId { get; set; }
        [Required]
        public virtual Team? Home { get; set; }
        public int HomeId { get; set; }
        public string? FinalScore { get; set; }
    }
}
