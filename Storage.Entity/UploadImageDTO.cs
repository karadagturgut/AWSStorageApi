using Microsoft.AspNetCore.Http;

namespace Storage.Entity
{
    public sealed record UploadImageDTO (IFormFile File);
   
}
