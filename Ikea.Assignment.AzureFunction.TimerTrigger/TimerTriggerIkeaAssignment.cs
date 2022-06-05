namespace Ikea.Assignment.AzureFunction.TimerTrigger
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application;
    using IkeaAssignmentCore.Application.Common.HttpClientHandler;
    using IkeaAssignmentCore.Infraestructure.Persistance;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class TimerTriggerIkeaAssignment
    {
        [FunctionName("TimerTriggerIkeaAssignment")]
        public static async Task Run(
            [TimerTrigger("0 0 0 * * *")] TimerInfo timer,
            ILogger log)
        {
            try
            {
                log.LogInformation($"Timer trigger function executed at: {DateTime.Now}");

                var service = new PhotoService(new HttpClientHandler(), new PhotoRepository());
                var photo = await service.GetPhotoAsync();

                var statictics = await service.GetPhotoStatisticsAsync(photo, string.Empty);
                await service.SavePhotoAsync(statictics);

                log.LogInformation($"Statictics: {JsonConvert.SerializeObject(statictics)}");
                log.LogInformation($"Timer trigger function completed execution at: {DateTime.Now}");
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
