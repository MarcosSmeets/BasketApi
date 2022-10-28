using BasketApi.Models;
using System.Text.Json.Serialization;

namespace BasketApi.Data.Dtos.Teams
{
    public class ReadTeamDto
    {
        public int Id { get; set; }
        public string? TeamName { get; set; }
        public string? TeamLogo { get; set; }
        public object? Players { get; set; }
    }
}
