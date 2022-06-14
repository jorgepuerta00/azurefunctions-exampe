namespace IkeaAssignmentCore.Domain.PhotoAggregate.Models
{
    using System;
    using IkeaAssignmentCore.Application.Models;

    public partial class PhotoModel
    {
        public string Id { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public UserModel User { get; set; }
        public Uri Url { get; set; }
        public decimal TotalDownloads { get; set; }
        public decimal PastDaysDownloads { get; set; }
        public decimal PercentagePastDaysDownloads { get; set; }

        public PhotoModel(Photo photo, PhotoStatistics statistics)
        {
            Id = photo.Id;
            Width = photo.Width;
            Height = photo.Height;
            User = new UserModel(photo.User);
            Url = photo.Urls.SmallS3;
            TotalDownloads = statistics.Downloads.Total;
            PastDaysDownloads = statistics.Downloads.Historical.Change;
            CalculatePercentagePastDaysDownloads();
        }

        private void CalculatePercentagePastDaysDownloads()
        {
            var percentage = PastDaysDownloads * 100 / TotalDownloads;
            PercentagePastDaysDownloads = Convert.ToDecimal(percentage.ToString("0.##"));
        }
    }

    public partial class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public UserModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
        }
    }
}