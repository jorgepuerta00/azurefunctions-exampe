namespace Test.Ikea.Assignment.Core.Repositories
{
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;

    public class MockPhotoRepository : IPhotoRepository
    {
        public PhotoModel Mapper(Photo photo)
        {
            var userModel = new UserModel()
            {
                Id = photo.User.Id,
                Name = photo.User.Name
            };

            var photoModel = new PhotoModel()
            {
                Id = photo.Id,
                Width = photo.Width,
                Height = photo.Height,
                TotalDownloads = photo.Downloads,
                User = userModel,
                Url = photo.Urls.SmallS3
            };

            return photoModel;
        }

        public Task<bool> Save(PhotoModel photoModel)
        {
            return Task.Run(() =>
            {
                return true;
            });
        }
    }
}
