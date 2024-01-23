

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;

namespace Shop.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly ShopContext _context;




        public FileServices
            (
            IHostEnvironment webHost,
            ShopContext context



            )
        {
            _webHost = webHost;
            _context = context;




        }




        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {


            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");

                }



                foreach (var image in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {

                        image.CopyTo(fileStream);


                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id,
                        };

                        _context.FileToApis.AddAsync(path);

                    }



                }


            }

        }

        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var imageId = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);

                var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\"
                    + imageId.ExistingFilePath;



                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                }
                _context.FileToApis.Remove(imageId);
                await _context.SaveChangesAsync();
            }


            return null;
        }



        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            var imageId = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\"
                + imageId.ExistingFilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToApis.Remove(imageId);
            await _context.SaveChangesAsync();

            return null;
        }



        public void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var file in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {

                        FilesToDatabase files = new FilesToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = file.FileName,
                            RealEstateId = domain.Id,

                        };
                        file.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FilesToDatabases.Add(files);


                    }

                }

            }
        }
        public async Task<FilesToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var image = await _context.FilesToDatabases
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _context.FilesToDatabases.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

        public async Task<FilesToDatabase> RemoveAllImagesByRealEstateId_with_a_record(FileToDatabaseDto[] dto)
        {

            foreach (var dtos in dto)
            {
                var photoId = await _context.FilesToDatabases
                    .Where(x => x.Id == dtos.Id)
                    .FirstOrDefaultAsync();

                _context.FilesToDatabases.Remove(photoId);
                await _context.SaveChangesAsync();

            }

            return null;
        }


        public async Task RemoveAllImagesByRealEstateId_without_deleting_a_record(Guid realEstateId)
        {
            var imagesToDelete = await _context.FilesToDatabases
                .Where(x => x.RealEstateId == realEstateId)
                .ToListAsync();

            foreach (var image in imagesToDelete)
            {
                _context.FilesToDatabases.Remove(image);
            }

            await _context.SaveChangesAsync();
        }




        //public async Task RemoveAllImagesByReal(FileToDatabaseDto[] dto)
        //{
        //    var imagesToDelete = await _context.FilesToDatabases
        //        .Where(x => x.Id ==  Dtos.Id)
        //        .ToListAsync();

        //    foreach (var image in imagesToDelete)
        //    {
        //        _context.FilesToDatabases.Remove(image);
        //    }

        //    await _context.SaveChangesAsync();
        //}













    }
}

