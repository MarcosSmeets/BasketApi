using System.Text.Json.Serialization;

namespace BasketApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? CountryName { get; set; }
        [JsonIgnore]
        public virtual List<Player>? Players { get; set; }
    }
}
