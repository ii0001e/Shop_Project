using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeather
{
    public class AcuWeatherForecastResponseRoot
    {
        [JsonPropertyName("Headline")]
        public Headline Headline { get; set; }

        [JsonPropertyName("DailyForecasts")]
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
