using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
        //array a few file at the same time
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);

        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);



        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);

        Task<FilesToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);



        Task RemoveAllImagesByRealEstateId_without_deleting_a_record(Guid realEstateId);

        Task<FilesToDatabase> RemoveAllImagesByRealEstateId_with_a_record(FileToDatabaseDto[] dto);
    }



}
