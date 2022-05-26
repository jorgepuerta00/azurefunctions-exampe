namespace Ikea.Assignment.Azure.Function.App
{
    using System;
    using System.IO;
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

    public static class IkeaAssignmentAzureFunctionApp
    {
        [FunctionName("HttpTriggerIkeaAssignment")]
        public static async Task<IActionResult> HttpTriggerIkeaAssignment(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try {
                var service = new PhotoService(new HttpClientHandler(), new PhotoRepository());
                var photo = await service.GetPhotoAsync();

                var statictics = await service.GetPhotoStatisticsAsync(photo, string.Empty);
                await service.SavePhotoAsync(statictics);

                return new FileContentResult(GetBytesFromImageURL(photo.Url.ToString()), "image/jpeg");
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                return new OkObjectResult(e.Message);
            }
        }

        [FunctionName("TimerTriggerIkeaAssignment")]
        public static async void TimerTriggerIkeaAssignment(
            [TimerTrigger("0 30 9 * * *")] TimerInfo timer,
            ILogger log)
        {
            try
            {
                if (timer.IsPastDue)
                {
                    log.LogInformation($"Timer trigger function executed at: {DateTime.Now}");

                    var service = new PhotoService(new HttpClientHandler(), new PhotoRepository());
                    var photo = await service.GetPhotoAsync();

                    var statictics = await service.GetPhotoStatisticsAsync(photo, string.Empty);
                    await service.SavePhotoAsync(statictics);
                }
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
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
