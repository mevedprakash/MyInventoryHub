
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Interface;

namespace Business.Services
{
    public interface IStorageService
    {
        Task<Picture> SaveImage(IFormFile image);
        void UploadImages(List<IFormFile> images);
    }
    public class StorageService : IStorageService
    {
        private readonly string folderPath = "uploads\\images";
        private readonly IHostingEnvironment _env;

        private readonly IUnitOfWork _unitOfWork;


        public StorageService(
            IHostingEnvironment env,
            IUnitOfWork unitOfWork
            )
        {
            this._env = env;
            this._unitOfWork = unitOfWork;
        }
        public async Task<Picture> SaveImage(IFormFile image)
        {
            var picture = new Picture()
            {
                Filename = image.FileName

            };
            _unitOfWork.PictureRepository.Add(picture);
            await _unitOfWork.SaveChangesAsync();
            string extension = Path.GetExtension(image.FileName);
            string fileName = $"{ picture.Id }-{picture.Filename}";
            var path = Path.Combine(_env.WebRootPath, folderPath).ToLower();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullFileLocation = Path.Combine(path, fileName).ToLower();
            using (var fileStream = new FileStream(fullFileLocation, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            //return Path.Combine(folderPath, fileName).Replace('\\', '/'); ;
            return picture;
        }

        public void UploadImages(List<IFormFile> images)
        {
            throw new NotImplementedException();
        }
    }
}
