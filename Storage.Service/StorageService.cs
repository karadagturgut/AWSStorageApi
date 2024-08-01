using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Service
{
    public class StorageService(IAmazonS3 _s3)
    {
        private readonly string bucketName = "tkfilebucket1";
        public async Task<PutObjectResponse> UploadImage(Guid id, IFormFile file)
        {
            var putObjectRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = $"images/{id}",
                ContentType = file.ContentType,
                InputStream = file.OpenReadStream(),
                Metadata =
                {
                ["x-amz-originalname"] = file.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(file.FileName)
                }
            };

            return await _s3.PutObjectAsync(putObjectRequest);
        }

        public async Task<GetObjectResponse> GetImage(Guid id)
        {
            var getObjectRequest = new GetObjectRequest { BucketName = bucketName, Key = $"images/{id}" };
            return await _s3.GetObjectAsync(getObjectRequest);
        }

        public async Task<DeleteObjectResponse> DeleteImage(Guid id)
        {
            var deleteObjectRequest = new DeleteObjectRequest { BucketName = bucketName, Key = $"images/{id}" };
            return await _s3.DeleteObjectAsync(deleteObjectRequest);
        }


    }
}
