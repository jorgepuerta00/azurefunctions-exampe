namespace IkeaAssignmentCore.Application
{
    using System;
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application.Common.ExtensionMethods;
    using IkeaAssignmentCore.Application.Common.Interfaces;
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;
    using Newtonsoft.Json;

    public class PhotoService
    {
        private readonly IHttpHandler _client;
        private readonly IPhotoRepository _photoRepository;
        private readonly AppConfiguration _configuration;

        public PhotoService(IHttpHandler client, IPhotoRepository photoRepository)
        {
            _client = client;
            _photoRepository = photoRepository;
            _configuration = new AppConfiguration();
        }

        public async Task<PhotoModel> GetPhotoAsync()
        {
            _configuration.UnsplashUrl.ThrowIfArgumentIsNull("Unsplash Url is null");

            var response = await _client.GetStringAsync(_configuration.UnsplashUrl);
            Photo photo = JsonConvert.DeserializeObject<Photo>(response);

            var photoModel = _photoRepository.Mapper(photo);

            return photoModel;
        }

        public async Task<PhotoModel> GetPhotoStatisticsAsync(PhotoModel photoModel, string days)
        {
            photoModel.ThrowIfArgumentIsNull("photoModel is null");
            _configuration.UnsplashUrlStatistics.ThrowIfArgumentIsNull("Unsplash Url Statistics is null");

            var url = _configuration.UnsplashUrlStatistics.Replace(":id", photoModel.Id);

            url = string.IsNullOrEmpty(days) ? url : string.Concat(url, "&quantity=" + days);

            var response = await _client.GetStringAsync(url);
            PhotoStatistics photo = JsonConvert.DeserializeObject<PhotoStatistics>(response);

            var totalDownloads = photo.Downloads.Total;
            var PastDaysDownloads = photo.Downloads.Historical.Change;
            var PercentagePastDaysDownloads = PastDaysDownloads * 100 / totalDownloads;

            var newPhotoModel = photoModel;

            newPhotoModel.TotalDownloads = totalDownloads;
            newPhotoModel.PastDaysDownloads = PastDaysDownloads;
            newPhotoModel.PercentagePastDaysDownloads = Convert.ToDecimal(PercentagePastDaysDownloads.ToString("0.##"));

            return newPhotoModel;
        }

        public async Task<bool> SavePhotoAsync(PhotoModel photoModel)
        {
            return await _photoRepository.Save(photoModel);
        }
    }
}