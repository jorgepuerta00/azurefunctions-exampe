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

        public async Task<bool> Save(PhotoModel photoModel)
        {
            try
            {
                photoModel.ThrowIfArgumentIsNull("photoModel is null");

                CloudTable table = _tableService.GetTableReference("photo");
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
