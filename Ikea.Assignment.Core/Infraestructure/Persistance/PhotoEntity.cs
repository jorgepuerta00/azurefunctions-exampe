namespace IkeaAssignmentCore.Infraestructure.Persistance
{
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;
    using Microsoft.Azure.Cosmos.Table;

    public class PhotoEntity : TableEntity
    {
        public string Id { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public double Downloads { get; set; }
        public double Change { get; set; }
        public double Percentage { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public PhotoEntity() { }

        public PhotoEntity(PhotoModel photoModel)
        {
            PartitionKey = photoModel.Id;
            RowKey = photoModel.Id;
            Id = photoModel.Id;
            Width = photoModel.Width;
            Height = photoModel.Height;
            Downloads = double.Parse(photoModel.TotalDownloads.ToString());
            Change = double.Parse(photoModel.PastDaysDownloads.ToString());
            Percentage = double.Parse(photoModel.PercentagePastDaysDownloads.ToString());
            UserId = photoModel.User.Id;
            UserName = photoModel.User.Name;
        }

    }
}
