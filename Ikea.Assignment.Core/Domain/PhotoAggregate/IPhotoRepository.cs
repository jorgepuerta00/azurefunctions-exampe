namespace IkeaAssignmentCore.Domain.PhotoAggregate
{
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;

    public interface IPhotoRepository
    {
        Task<bool> Save(PhotoModel photoModel);
    }
}