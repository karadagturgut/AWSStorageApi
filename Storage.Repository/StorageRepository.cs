using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Repository
{
    public class StorageRepository
    {
        public Task<PutObjectResponse> UploadImage(Guid id, IFormFile file)
        {

        }

        public Task<GetObjectResponse> GetImage(Guid id, IFormFile file)
        {

        }

        public Task<DeleteObjectResponse> DeleteImage(Guid id, IFormFile file)
        {

        }
    }
}
