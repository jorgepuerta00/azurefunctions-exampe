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

        public PhotoService(IHttpHandler client, IPhotoRepository photoRepository, AppConfiguration configuration)
        {
            _client = client;
            _photoRepository = photoRepository;
            _configuration = configuration;
        }

        public async Task<Photo> GetPhotoAsync()
        {
            _configuration.UnsplashUrl().ThrowIfArgumentIsNull("Unsplash Url is null");

            var response = await _client.GetStringAsync(_configuration.UnsplashUrl());
            Photo photo = JsonConvert.DeserializeObject<Photo>(response);

            return photo;
        }

        public async Task<PhotoModel> GetPhotoStatisticsAsync(Photo photo, string days)
        {
            photo.ThrowIfArgumentIsNull("photoModel is null");
            _configuration.UnsplashUrlStatistics().ThrowIfArgumentIsNull("Unsplash Url Statistics is null");

            var url = _configuration.UnsplashUrlStatistics().Replace(":id", photo.Id);

            url = url.ConcatUrl(days);

            var response = await _client.GetStringAsync(url);
            PhotoStatistics photoStatictis = JsonConvert.DeserializeObject<PhotoStatistics>(response);

            return new PhotoModel(photo, photoStatictis);
        }

        public async Task<bool> SavePhotoAsync(PhotoModel photoModel)
        {
            return await _photoRepository.Save(photoModel);
        }
    }
}