using Shop.Core.Dto.CoctailDto;
using Shop.Core.ServiceInterface;
using System.Net;
using System.Text.Json;

namespace Shop.ApplicationServices.Services
{
    public class CoctailServices : ICoctailServices
    {
        public async Task<CoctailresultDto> CoctailResult(CoctailresultDto dto)
        {

            string idCoctailAPI = "1";
            string url = $"https://www.thecocktaildb.com/api/json/v1/{idCoctailAPI}/search.php?s={dto.strDrink}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                CoctailRespondRootDto coctailResult = JsonSerializer.Deserialize<CoctailRespondRootDto>(json);

                dto.idDrink = coctailResult.drinks[0].idDrink;
                dto.strDrink = coctailResult.drinks[0].strDrink;
                dto.strDrinkAlternate = coctailResult.drinks[0].strDrinkAlternate;

                dto.strTags = coctailResult.drinks[0].strTags;
                dto.strVideo = coctailResult.drinks[0].strVideo;
                dto.strCategory = coctailResult.drinks[0].strCategory;
                dto.strIBA = coctailResult.drinks[0].strIBA;
                dto.strAlcoholic = coctailResult.drinks[0].strAlcoholic;
                dto.strGlass = coctailResult.drinks[0].strGlass;
                dto.strInstructions = coctailResult.drinks[0].strInstructions;
                dto.strInstructionsES = coctailResult.drinks[0].strInstructionsES;
                dto.strInstructionsDE = coctailResult.drinks[0].strInstructionsDE;
                dto.strInstructionsFR = coctailResult.drinks[0].strInstructionsFR;
                dto.strInstructionsIT = coctailResult.drinks[0].strInstructionsIT;
                dto.strInstructionsZHHANS = coctailResult.drinks[0].strInstructionsZHHANS;
                dto.strInstructionsZHHANT = coctailResult.drinks[0].strInstructionsZHHANT;
                dto.strDrinkThumb = coctailResult.drinks[0].strDrinkThumb;

                dto.strIngredient1 = coctailResult.drinks[0].strIngredient1;
                dto.strIngredient2 = coctailResult.drinks[0].strIngredient2;
                dto.strIngredient3 = coctailResult.drinks[0].strIngredient3;
                dto.strIngredient4 = coctailResult.drinks[0].strIngredient4;
                dto.strIngredient5 = coctailResult.drinks[0].strIngredient5;
                dto.strIngredient6 = coctailResult.drinks[0].strIngredient6;
                dto.strIngredient7 = coctailResult.drinks[0].strIngredient7;
                dto.strIngredient8 = coctailResult.drinks[0].strIngredient8;
                dto.strIngredient9 = coctailResult.drinks[0].strIngredient9;
                dto.strIngredient10 = coctailResult.drinks[0].strIngredient10;
                dto.strIngredient11 = coctailResult.drinks[0].strIngredient11;
                dto.strIngredient12 = coctailResult.drinks[0].strIngredient12;
                dto.strIngredient13 = coctailResult.drinks[0].strIngredient13;
                dto.strIngredient14 = coctailResult.drinks[0].strIngredient14;
                dto.strIngredient15 = coctailResult.drinks[0].strIngredient15;

                dto.strMeasure1 = coctailResult.drinks[0].strMeasure1;
                dto.strMeasure2 = coctailResult.drinks[0].strMeasure2;
                dto.strMeasure3 = coctailResult.drinks[0].strMeasure3;
                dto.strMeasure4 = coctailResult.drinks[0].strMeasure4;
                dto.strMeasure5 = coctailResult.drinks[0].strMeasure5;
                dto.strMeasure6 = coctailResult.drinks[0].strMeasure6;
                dto.strMeasure7 = coctailResult.drinks[0].strMeasure7;
                dto.strMeasure8 = coctailResult.drinks[0].strMeasure8;
                dto.strMeasure9 = coctailResult.drinks[0].strMeasure9;
                dto.strMeasure10 = coctailResult.drinks[0].strMeasure10;
                dto.strMeasure11 = coctailResult.drinks[0].strMeasure11;
                dto.strMeasure12 = coctailResult.drinks[0].strMeasure12;
                dto.strMeasure13 = coctailResult.drinks[0].strMeasure13;
                dto.strMeasure14 = coctailResult.drinks[0].strMeasure14;
                dto.strMeasure15 = coctailResult.drinks[0].strMeasure15;

                dto.strImageSource = coctailResult.drinks[0].strImageSource;
                dto.strImageAttribution = coctailResult.drinks[0].strImageAttribution;
                dto.strCreativeCommonsConfirmed = coctailResult.drinks[0].strCreativeCommonsConfirmed;
                dto.dateModified = coctailResult.drinks[0].dateModified;

            }

            return dto;
        }

    }
}

