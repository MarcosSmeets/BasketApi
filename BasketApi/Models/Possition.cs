using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BasketApi.Models
{
    public class Possition
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? PlayerPossition { get; set; }
        [JsonIgnore]
        public virtual List<Player>? Players { get; set; }
    }
}
