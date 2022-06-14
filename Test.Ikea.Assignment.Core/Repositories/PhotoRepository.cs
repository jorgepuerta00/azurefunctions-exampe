namespace Test.Ikea.Assignment.Core.Repositories
{
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;

    public class MockPhotoRepository : IPhotoRepository
    {
        public Task<bool> Save(PhotoModel photoModel)
        {
            return Task.Run(() =>
            {
                return true;
            });
        }
    }
}
