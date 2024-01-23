namespace Shop.Models.OpenWeathers
{
    public class OpenWeatherViewModel
    {
        public string City { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double WeatherId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public int Visibility { get; set; }
        public double WindSpeed { get; set; }

    }
}
