namespace IkeaAssignmentCore.Application.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Photo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("promoted_at")]
        public DateTimeOffset PromotedAt { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("blur_hash")]
        public string BlurHash { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("likes")]
        public long Likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool LikedByUser { get; set; }

        [JsonProperty("topic_submissions")]
        public TopicSubmissions TopicSubmissions { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("downloads")]
        public long Downloads { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("html")]
        public Uri Html { get; set; }

        [JsonProperty("download")]
        public Uri Download { get; set; }

        [JsonProperty("download_location")]
        public Uri DownloadLocation { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public partial class TopicSubmissions
    {
        [JsonProperty("street-photography")]
        public StreetPhotography StreetPhotography { get; set; }
    }

    public partial class StreetPhotography
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Urls
    {
        [JsonProperty("raw")]
        public Uri Raw { get; set; }

        [JsonProperty("full")]
        public Uri Full { get; set; }

        [JsonProperty("regular")]
        public Uri Regular { get; set; }

        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("thumb")]
        public Uri Thumb { get; set; }

        [JsonProperty("small_s3")]
        public Uri SmallS3 { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty("portfolio_url")]
        public string PortfolioUrl { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("links")]
        public UserLinks Links { get; set; }

        [JsonProperty("profile_image")]
        public ProfileImage ProfileImage { get; set; }

        [JsonProperty("instagram_username")]
        public string InstagramUsername { get; set; }

        [JsonProperty("total_collections")]
        public long TotalCollections { get; set; }

        [JsonProperty("total_likes")]
        public long TotalLikes { get; set; }

        [JsonProperty("total_photos")]
        public long TotalPhotos { get; set; }

        [JsonProperty("accepted_tos")]
        public bool AcceptedTos { get; set; }

        [JsonProperty("for_hire")]
        public bool ForHire { get; set; }

        [JsonProperty("social")]
        public Social Social { get; set; }
    }

    public partial class UserLinks
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("html")]
        public Uri Html { get; set; }

        [JsonProperty("photos")]
        public Uri Photos { get; set; }

        [JsonProperty("likes")]
        public Uri Likes { get; set; }

        [JsonProperty("portfolio")]
        public Uri Portfolio { get; set; }

        [JsonProperty("following")]
        public Uri Following { get; set; }

        [JsonProperty("followers")]
        public Uri Followers { get; set; }
    }

    public partial class ProfileImage
    {
        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [JsonProperty("large")]
        public Uri Large { get; set; }
    }

    public partial class Social
    {
        [JsonProperty("instagram_username")]
        public string InstagramUsername { get; set; }

        [JsonProperty("portfolio_url")]
        public string PortfolioUrl { get; set; }

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty("paypal_email")]
        public string PaypalEmail { get; set; }
    }

}