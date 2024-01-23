using Shop.Core.Dto.CuckNorrisDto;

namespace Shop.Core.ServiceInterface
{
    public interface ICackNorisServices
    {
        Task<ChackNorisResultDto> ChackNorrisResult(ChackNorisResultDto dto);


    }
}
