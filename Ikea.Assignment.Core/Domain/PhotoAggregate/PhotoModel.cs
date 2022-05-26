namespace IkeaAssignmentCore.Domain.PhotoAggregate.Models
{
    using System;

    public partial class PhotoModel
    {
        public string Id { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public UserModel User { get; set; }
        public decimal TotalDownloads { get; set; }
        public decimal PastDaysDownloads { get; set; }
        public decimal PercentagePastDaysDownloads { get; set; }
        public Uri Url { get; set; }
    }

    public partial class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}