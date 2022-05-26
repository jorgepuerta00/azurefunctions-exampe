namespace IkeaAssignmentCore.Domain.PhotoAggregate
{
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;

    public interface IPhotoRepository
    {
        PhotoModel Mapper(Photo photo);
        Task<bool> Save(PhotoModel photoModel);
    }
}