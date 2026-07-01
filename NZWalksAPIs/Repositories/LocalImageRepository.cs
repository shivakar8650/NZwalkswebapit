using Microsoft.EntityFrameworkCore;
using NZWalksAPIs.Controllers;
using NZWalksAPIs.Data;
using NZWalksAPIs.Model.Domain;

namespace NZWalksAPIs.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly NZWalkDBContext _dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor,
            NZWalkDBContext dBContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dBContext;
        }
        public async Task<Image> Upload(Image image)
        {

            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath,"Images",
                $"{image.FileName}{image.FileExtension}");
            //Upload the image to the local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // http://localhost:5000/Images/image.jpg

            var urlfilepath  = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.filePath = urlfilepath;

            //Add Images to the Images table 

            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;

            
        }
    }
}
