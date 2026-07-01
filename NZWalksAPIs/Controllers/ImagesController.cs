using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using NZWalksAPIs.Model.Domain;
using NZWalksAPIs.Model.DTO;
using NZWalksAPIs.Repositories;

namespace NZWalksAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController( IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        // POST : api/Images/Upload 

        [HttpPost]
        [Route("Upload")]
        public  async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if(ModelState.IsValid)
            {
                // convert DTO to Domain model
                var imageDomainModel = new Image
                {
                    File = request.file,
                    FileExtension = Path.GetExtension(request.file.FileName),
                    FileSizeInBytes = request.file.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                await _imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);

                // user repository to upload image 

            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtenstion = new string[] { ".jpg", ".jpeg", ".png" };

            if(allowedExtenstion.Contains(Path.GetExtension(request.file.FileName)) == false )
            {
                ModelState.AddModelError("file", "Unsuported file extenstion");
            }

            if(request.file.Length > 10485760)
            {
                ModelState.AddModelError("File", "File size more than 10 MB , Please upload a smaller size file.");
            }
        }
    }
}
