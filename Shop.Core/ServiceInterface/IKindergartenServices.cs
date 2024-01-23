using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IKindergartenServices
    {
        Task<KinderGarten> Create(KinderGartenDto dto);

        Task<KinderGarten> GetAsync(Guid id);

        Task<KinderGarten> Update(KinderGartenDto dto);

        Task<KinderGarten> Delete(Guid id);
    }
}
