using Shop.Core.Dto.AccuWeather;

namespace Shop.Core.ServiceInterface
{
    public interface IAcuWeatherServices
    {
        Task<AcuWeatherResultDto> AcuWeatherResult(AcuWeatherResultDto dto);
    }
}
