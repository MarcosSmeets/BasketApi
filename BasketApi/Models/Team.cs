using System.ComponentModel.DataAnnotations;

namespace BasketApi.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? TeamName { get; set; }
        public string? TeamLogo { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
