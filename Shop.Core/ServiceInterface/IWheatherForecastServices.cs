using Shop.Core.Dto.OpenWeastherDtos;

namespace Shop.Core.ServiceInterface
{
    public interface IWheatherForecastServices
    {
        Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
