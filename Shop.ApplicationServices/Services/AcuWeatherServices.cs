using Nancy.Json;
using Shop.Core.Dto.AccuWeather;
using Shop.Core.ServiceInterface;
using System.Net;

namespace Shop.ApplicationServices.Services
{
    public class AcuWeatherServices : IAcuWeatherServices
    {




        public async Task<AcuWeatherResultDto> AcuWeatherResult(AcuWeatherResultDto dto)
        {
            string AccuWeatherAPI = "i70Wd9OmFAm1ioGnnDN440GLIQnxbdnJ";

            using (WebClient client = new WebClient())
            {
                // Location API call to get the key (id) of the city
                string searchUrl = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={AccuWeatherAPI}&q={dto.City}";

                try
                {
                    string searchJson = client.DownloadString(searchUrl);
                    AcuWeatherRespondDto locationResult = new JavaScriptSerializer().Deserialize<List<AcuWeatherRespondDto>>(searchJson).FirstOrDefault();

                    dto.Key = locationResult.Key;

                    // Forecast API call
                    string forecastUrl = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.Key}?apikey={AccuWeatherAPI}";
                    string forecastJson = client.DownloadString(forecastUrl);
                    AcuWeatherForecastResponseRoot forecastResult = new JavaScriptSerializer().Deserialize<AcuWeatherForecastResponseRoot>(forecastJson);

                    dto.Minimum = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Minimum.Value;
                    dto.Maximum = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Maximum.Value;
                    dto.Link = forecastResult.DailyForecasts.FirstOrDefault().Link;
                }
                catch (WebException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return dto;
        }





    }
}







