using Shop.Core.Dto.CuckNorrisDto;
using Shop.Core.ServiceInterface;
using System.Text.Json;

namespace Shop.ApplicationServices.Services
{
    public class ChackNorisServices : ICackNorisServices
    {
        public async Task<ChackNorisResultDto> ChackNorrisResult(ChackNorisResultDto dto)
        {
            string url = "https://api.chucknorris.io/jokes/random";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                ChackNorisRespondRootDto chuckNorrisResult = JsonSerializer.Deserialize<ChackNorisRespondRootDto>(json);

                dto.categories = chuckNorrisResult.Categories;

                dto.icon_url = chuckNorrisResult.IconUrl;
                dto.id = chuckNorrisResult.Id;
                //dto.updated_at = DateTime.ParseExact(chuckNorrisResult.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss.ffffff"), "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
                dto.url = chuckNorrisResult.Url;
                dto.value = chuckNorrisResult.Value;
            }

            return dto;



        }





    }

}

