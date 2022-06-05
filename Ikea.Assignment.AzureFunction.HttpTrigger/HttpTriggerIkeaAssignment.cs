﻿namespace Ikea.Assignment.AzureFunction.HttpTrigger
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application;
    using IkeaAssignmentCore.Application.Common.HttpClientHandler;
    using IkeaAssignmentCore.Infraestructure.Persistance;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class HttpTriggerIkeaAssignment
    {
        [FunctionName("HttpTriggerIkeaAssignment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var service = new PhotoService(new HttpClientHandler(), new PhotoRepository());
                var photo = await service.GetPhotoAsync();

                var statictics = await service.GetPhotoStatisticsAsync(photo, "10");
                await service.SavePhotoAsync(statictics);

                log.LogInformation($"Statictics: {JsonConvert.SerializeObject(statictics)}");

                return new FileContentResult(GetBytesFromImageURL(photo.Url.ToString()), "image/jpeg");
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                return new OkObjectResult(e.Message);
            }
        }

        public static byte[] GetBytesFromImageURL(string StrImageUrl)
        {
            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(StrImageUrl);
                return imageBytes;
            }
        }
    }
}