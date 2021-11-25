using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace PetBook.Infrastructure.Repository
{
    public class CloudRepository : IRepository
    {
        private IConfiguration _configuration;
        private const string containerName = "reports";
        


        public CloudRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void SaveFile(string content, string reportName)
        {
            var blobClient = new BlobClient(_configuration.GetConnectionString("storageDefaultConnection"),
                containerName, $"{reportName}.txt");
            await using var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
            await blobClient.UploadAsync( ms, true);
        }
    }
}
