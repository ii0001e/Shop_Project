using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.OpenWeastherDtos;
using Shop.Core.ServiceInterface;
using Shop.Models.OpenWeathers;

namespace Shop.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IWheatherForecastServices _weatherForecastServices;

        public OpenWeathersController
        (
            IWheatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }



        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeathers", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new();
            dto.City = city;

            _weatherForecastServices.OpenWeatherResult(dto);
            OpenWeatherViewModel vm = new();


            vm.City = dto.City;
            vm.Lon = dto.Lon;
            vm.Lat = dto.Lat;
            vm.WeatherId = dto.WeatherId;
            vm.Main = dto.Main;
            vm.Description = dto.Description;
            vm.Icon = dto.Icon;
            vm.Temp = dto.Temp;
            vm.FeelsLike = dto.FeelsLike;
            vm.TempMin = dto.TempMin;
            vm.TempMax = dto.TempMax;
            vm.Pressure = dto.Pressure;
            vm.Humidity = dto.Humidity;
            vm.SeaLevel = dto.SeaLevel;
            vm.GrndLevel = dto.GrndLevel;
            vm.Visibility = dto.Visibility;
            vm.WindSpeed = dto.WindSpeed;

            return View(vm);

        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
