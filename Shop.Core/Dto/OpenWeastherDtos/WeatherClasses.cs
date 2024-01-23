using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeastherDtos
{
    public class WeatherClasses
    {

        public class Clouds
        {
            [JsonPropertyName("all")]
            public int All { get; set; }
        }

        public class Coord
        {
            [JsonPropertyName("lon")]
            public double Lon { get; set; }

            [JsonPropertyName("lat")]
            public double Lat { get; set; }
        }

        public class Main
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public double Feels_like { get; set; }

            [JsonPropertyName("temp_min")]
            public double Temp_min { get; set; }

            [JsonPropertyName("temp_max")]
            public double Temp_max { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("sea_level")]
            public int Sea_level { get; set; }

            [JsonPropertyName("grnd_level")]
            public int Grnd_level { get; set; }
        }

        public class Rain
        {
            [JsonPropertyName("1h")]
            public double _1h { get; set; }

            [JsonPropertyName("3h")]
            public double _3h { get; set; }
        }

        public class Snow
        {
            [JsonPropertyName("1h")]
            public double _1h { get; set; }

            [JsonPropertyName("3h")]
            public double _3h { get; set; }
        }

        public class Sys
        {
            [JsonPropertyName("type")]
            public int Type { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("sunrise")]
            public int Sunrise { get; set; }

            [JsonPropertyName("sunset")]
            public int Sunset { get; set; }

        }

        public class Weather
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

        public class Wind
        {
            [JsonPropertyName("speed")]
            public double Speed { get; set; }

            [JsonPropertyName("deg")]
            public int Deg { get; set; }

            [JsonPropertyName("gust")]
            public double Gust { get; set; }
        }
    }
}
