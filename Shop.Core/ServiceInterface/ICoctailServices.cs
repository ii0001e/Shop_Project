using Shop.Core.Dto.CoctailDto;

namespace Shop.Core.ServiceInterface
{
    public interface ICoctailServices
    {
        Task<CoctailresultDto> CoctailResult(CoctailresultDto dto);
    }
}
