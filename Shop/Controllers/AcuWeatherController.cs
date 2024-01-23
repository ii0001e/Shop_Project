using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.AccuWeather;
using Shop.Core.ServiceInterface;
using Shop.Models.Acuweather;

namespace Shop.Controllers
{
    public class AcuWeatherController : Controller
    {


        private readonly IAcuWeatherServices _accuweatherServices;


        public AcuWeatherController(IAcuWeatherServices acuWeatherServices)
        {
            _accuweatherServices = acuWeatherServices;
        }

        [HttpPost]
        public IActionResult SearchCity(SeachAcuweatherViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Acuweather", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {

            AcuWeatherResultDto dto = new AcuWeatherResultDto();


            dto.City = city;

            _accuweatherServices.AcuWeatherResult(dto);



            AcuweatherIndexViewModel vm = new AcuweatherIndexViewModel
            {

                City = dto.City,

                Minimum = dto.Minimum,
                Maximum = dto.Maximum,
                Link = dto.Link,

            };


            return View(vm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }

}
