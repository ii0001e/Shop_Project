﻿using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.CoctailDto;
using Shop.Core.ServiceInterface;
using Shop.Models.Coctails;

namespace Shop.Controllers
{
    public class CoctailsController : Controller
    {

        private readonly ICoctailServices _coctailServices;


        public CoctailsController(ICoctailServices CoctailServices)
        {
            _coctailServices = CoctailServices;
        }

        [HttpPost]
        public IActionResult SearchCoctail(SeachCoctailViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Coctail", "Coctails", new { coctail = model.CoctailName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Coctail(string coctail)
        {
            CoctailresultDto dto = new();
            dto.strDrink = coctail;

            _coctailServices.CoctailResult(dto);


            CoctailsIndexViewModel vm = new CoctailsIndexViewModel
            {
                idDrink = dto.idDrink,
                strDrink = dto.strDrink,
                strDrinkAlternate = dto.strDrinkAlternate,
                strTags = dto.strTags,
                strVideo = dto.strVideo,
                strCategory = dto.strCategory,
                strIBA = dto.strIBA,
                strAlcoholic = dto.strAlcoholic,
                strGlass = dto.strGlass,
                strInstructions = dto.strInstructions,
                strInstructionsES = dto.strInstructionsES,
                strInstructionsDE = dto.strInstructionsDE,
                strInstructionsFR = dto.strInstructionsFR,
                strInstructionsIT = dto.strInstructionsIT,
                strInstructionsZHHANS = dto.strInstructionsZHHANS,
                strInstructionsZHHANT = dto.strInstructionsZHHANT,
                strDrinkThumb = dto.strDrinkThumb,
                strIngredient1 = dto.strIngredient1,
                strIngredient2 = dto.strIngredient2,
                strIngredient3 = dto.strIngredient3,
                strIngredient4 = dto.strIngredient4,
                strIngredient5 = dto.strIngredient5,
                strIngredient6 = dto.strIngredient6,
                strIngredient7 = dto.strIngredient7,
                strIngredient8 = dto.strIngredient8,
                strIngredient9 = dto.strIngredient9,
                strIngredient10 = dto.strIngredient10,
                strIngredient11 = dto.strIngredient11,
                strIngredient12 = dto.strIngredient12,
                strIngredient13 = dto.strIngredient13,
                strIngredient14 = dto.strIngredient14,
                strIngredient15 = dto.strIngredient15,
                strMeasure1 = dto.strMeasure1,
                strMeasure2 = dto.strMeasure2,
                strMeasure3 = dto.strMeasure3,
                strMeasure4 = dto.strMeasure4,
                strMeasure5 = dto.strMeasure5,
                strMeasure6 = dto.strMeasure6,
                strMeasure7 = dto.strMeasure7,
                strMeasure8 = dto.strMeasure8,
                strMeasure9 = dto.strMeasure9,
                strMeasure10 = dto.strMeasure10,
                strMeasure11 = dto.strMeasure11,
                strMeasure12 = dto.strMeasure12,
                strMeasure13 = dto.strMeasure13,
                strMeasure14 = dto.strMeasure14,
                strMeasure15 = dto.strMeasure15,
                strImageSource = dto.strImageSource,
                strImageAttribution = dto.strImageAttribution,
                strCreativeCommonsConfirmed = dto.strCreativeCommonsConfirmed,
                dateModified = dto.dateModified
            };



            return View(vm);
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
