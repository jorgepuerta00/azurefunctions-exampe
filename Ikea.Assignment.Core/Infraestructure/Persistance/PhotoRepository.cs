namespace IkeaAssignmentCore.Infraestructure.Persistance
{
    using System.Threading.Tasks;
    using Application.Common.ExtensionMethods;
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;
    using IkeaAssignmentCore.Infraestructure.Persistance.common;
    using Microsoft.Azure.Cosmos.Table;

    public class PhotoRepository : IPhotoRepository
    {
        private readonly TableService _tableService;

        public PhotoRepository()
        {
            _tableService = new TableService();
        }

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
                User = userModel,
                Url = photo.Urls.SmallS3
            };

            return photoModel;
        }

        public async Task<bool> Save(PhotoModel photoModel)
        {
            try
            {
                photoModel.ThrowIfArgumentIsNull("photoModel is null");

                CloudTable table = _tableService.GetTableReference("photo", true);
                var entity = new PhotoEntity(photoModel);

                await _tableService.AddObject(table, entity);

                return true;
            } catch
            {
                return false;
            }
        }
    }
}
