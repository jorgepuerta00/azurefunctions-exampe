namespace IkeaAssignmentCore.Application.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class PhotoStatistics
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("downloads")]
        public Downloads Downloads { get; set; }

        [JsonProperty("views")]
        public Downloads Views { get; set; }

        [JsonProperty("likes")]
        public Downloads Likes { get; set; }
    }

    public partial class Downloads
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("historical")]
        public Historical Historical { get; set; }
    }

    public partial class Historical
    {
        [JsonProperty("change")]
        public long Change { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("values")]
        public Value[] Values { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("value")]
        public long ValueValue { get; set; }
    }
}
