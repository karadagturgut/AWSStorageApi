using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Entity;
using Storage.Service;

namespace StorageApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StorageController(StorageService _storageService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageDTO model)
        {
            var response = await _storageService.UploadImage(Guid.NewGuid(), model.File);
            return StatusCode((int)response.HttpStatusCode,response.HttpStatusCode);
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(Guid id)
        {
            try
            {
                var response = await _storageService.GetImage(id);
                return File(response.ResponseStream, response.Headers.ContentType);
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var response = await _storageService.DeleteImage(id);
            return StatusCode((int)response.HttpStatusCode,response.HttpStatusCode);
        }
    }
}
