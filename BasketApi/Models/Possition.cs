using System.ComponentModel.DataAnnotations;

namespace BasketApi.Models
{
    public class Possition
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? PlayerPossition { get; set; }
        public virtual List<Player>? Players { get; set; }
    }
}
