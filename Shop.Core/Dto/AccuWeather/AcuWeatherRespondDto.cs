using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeather
{
    public class AcuWeatherRespondDto
    {
        [JsonPropertyName("Key")]
        public string Key { get; set; }

        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("Level")]
        public int Level { get; set; }

        [JsonPropertyName("LocalizedType")]
        public string LocalizedType { get; set; }

        [JsonPropertyName("EnglishType")]
        public string EnglishType { get; set; }

        [JsonPropertyName("CountryID")]
        public string CountryID { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("EpochDate")]
        public int EpochDate { get; set; }

        [JsonPropertyName("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("Day")]
        public Day Day { get; set; }

        [JsonPropertyName("Night")]
        public Night Night { get; set; }

        [JsonPropertyName("Sources")]
        public List<string> Sources { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }

        [JsonPropertyName("Icon")]
        public int Icon { get; set; }

        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonPropertyName("PrecipitationType")]
        public string PrecipitationType { get; set; }

        [JsonPropertyName("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }

        [JsonPropertyName("Metric")]
        public Metric Metric { get; set; }

        [JsonPropertyName("Imperial")]
        public Imperial Imperial { get; set; }

        [JsonPropertyName("Latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("Longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("Elevation")]
        public Elevation Elevation { get; set; }

        [JsonPropertyName("EffectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("EffectiveEpochDate")]
        public int EffectiveEpochDate { get; set; }

        [JsonPropertyName("Severity")]
        public int Severity { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("EndEpochDate")]
        public int EndEpochDate { get; set; }

        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }

        [JsonPropertyName("Minimum")]
        public Minimum Minimum { get; set; }

        [JsonPropertyName("Maximum")]
        public Maximum Maximum { get; set; }

        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("GmtOffset")]
        public int GmtOffset { get; set; }

        [JsonPropertyName("IsDaylightSaving")]
        public bool IsDaylightSaving { get; set; }

        [JsonPropertyName("NextOffsetChange")]
        public DateTime NextOffsetChange { get; set; }
    }



    public class AdministrativeArea
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("Level")]
        public int Level { get; set; }

        [JsonPropertyName("LocalizedType")]
        public string LocalizedType { get; set; }

        [JsonPropertyName("EnglishType")]
        public string EnglishType { get; set; }

        [JsonPropertyName("CountryID")]
        public string CountryID { get; set; }
    }
    public class Country
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }
    }

    public class DailyForecast
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("EpochDate")]
        public int EpochDate { get; set; }

        [JsonPropertyName("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("Day")]
        public Day Day { get; set; }

        [JsonPropertyName("Night")]
        public Night Night { get; set; }

        [JsonPropertyName("Sources")]
        public List<string> Sources { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }
    }

    public class Day
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }

        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonPropertyName("PrecipitationType")]
        public string PrecipitationType { get; set; }

        [JsonPropertyName("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }
    }

    public class Elevation
    {
        [JsonPropertyName("Metric")]
        public Metric Metric { get; set; }

        [JsonPropertyName("Imperial")]
        public Imperial Imperial { get; set; }
    }

    public class GeoPosition
    {
        [JsonPropertyName("Latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("Longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("Elevation")]
        public Elevation Elevation { get; set; }
    }

    public class Headline
    {
        [JsonPropertyName("EffectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("EffectiveEpochDate")]
        public int EffectiveEpochDate { get; set; }

        [JsonPropertyName("Severity")]
        public int Severity { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("EndEpochDate")]
        public int EndEpochDate { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }
    }

    public class Imperial
    {
        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }

    public class Maximum
    {
        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }

    public class Metric
    {
        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }

    public class Minimum
    {
        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }

    public class Night
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }

        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }
    }

    public class Region
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }
    }

    public class SupplementalAdminArea
    {
        [JsonPropertyName("Level")]
        public int Level { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }
    }

    public class Temperature
    {
        [JsonPropertyName("Minimum")]
        public Minimum Minimum { get; set; }

        [JsonPropertyName("Maximum")]
        public Maximum Maximum { get; set; }
    }

    public class TimeZone
    {
        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("GmtOffset")]
        public int GmtOffset { get; set; }

        [JsonPropertyName("IsDaylightSaving")]
        public bool IsDaylightSaving { get; set; }

        [JsonPropertyName("NextOffsetChange")]
        public DateTime NextOffsetChange { get; set; }
    }


}


