using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.CuckNorrisDto;
using Shop.Core.ServiceInterface;
using Shop.Models.ChackNorris;

namespace Shop.Controllers
{
    public class ChackNorrisController : Controller
    {
        private readonly ICackNorisServices _ChackNorisServices;

        public ChackNorrisController(ICackNorisServices ChackNorisServices)
        {
            _ChackNorisServices = ChackNorisServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChackJoke()
        {
            ChackNorisResultDto dto = new ChackNorisResultDto();
            await _ChackNorisServices.ChackNorrisResult(dto);
            return RedirectToAction("Chack", dto);
        }

        [HttpGet]
        public IActionResult Chack(ChackNorisResultDto dto)
        {
            ChackNorrisViewModel vm = new ChackNorrisViewModel
            {
                categories = dto.categories,
                created_at = dto.created_at,
                icon_url = dto.icon_url,
                id = dto.id,
                updated_at = dto.updated_at,
                url = dto.url,
                value = dto.value
            };

            return View(vm);
        }









    }
}
