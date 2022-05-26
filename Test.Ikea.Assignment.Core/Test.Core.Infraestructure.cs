namespace Test.Ikea.Assignment.Core
{
    using IkeaAssignmentCore.Application.Models;
    using IkeaAssignmentCore.Domain.PhotoAggregate.Models;
    using IkeaAssignmentCore.Infraestructure.Persistance;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class UnitTestInfraestructure
    {
        [TestMethod]
        public void TestRepositoryPhotoModelMapper()
        {
            // Arrange
            var data = "{\"id\":\"rJkfSLTmubc\",\"created_at\":\"2022-05-04T14:39:56-04:00\",\"updated_at\":\"2022-05-25T12:25:42-04:00\",\"promoted_at\":\"2022-05-05T04:20:40-04:00\",\"width\":3936,\"height\":2624,\"color\":\"#262626\",\"blur_hash\":\"L8AAXR=_4mVr?G.8IUt6D%RP-=WF\",\"description\":null,\"alt_description\":null,\"urls\":{\"raw\":\"https://images.unsplash.com/photo-1651688730796-151972ba8f87?crop=entropy\\u0026cs=tinysrgb\\u0026fm=jpg\\u0026ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\\u0026ixlib=rb-1.2.1\\u0026q=80\\u0026raw_url=true\",\"full\":\"https://images.unsplash.com/photo-1651688730796-151972ba8f87?crop=entropy\\u0026cs=tinysrgb\\u0026fm=jpg\\u0026ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\\u0026ixlib=rb-1.2.1\\u0026q=80\",\"regular\":\"https://images.unsplash.com/photo-1651688730796-151972ba8f87?crop=entropy\\u0026cs=tinysrgb\\u0026fit=max\\u0026fm=jpg\\u0026ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\\u0026ixlib=rb-1.2.1\\u0026q=80\\u0026w=1080\",\"small\":\"https://images.unsplash.com/photo-1651688730796-151972ba8f87?crop=entropy\\u0026cs=tinysrgb\\u0026fit=max\\u0026fm=jpg\\u0026ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\\u0026ixlib=rb-1.2.1\\u0026q=80\\u0026w=400\",\"thumb\":\"https://images.unsplash.com/photo-1651688730796-151972ba8f87?crop=entropy\\u0026cs=tinysrgb\\u0026fit=max\\u0026fm=jpg\\u0026ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\\u0026ixlib=rb-1.2.1\\u0026q=80\\u0026w=200\",\"small_s3\":\"https://s3.us-west-2.amazonaws.com/images.unsplash.com/small/photo-1651688730796-151972ba8f87\"},\"links\":{\"self\":\"https://api.unsplash.com/photos/rJkfSLTmubc\",\"html\":\"https://unsplash.com/photos/rJkfSLTmubc\",\"download\":\"https://unsplash.com/photos/rJkfSLTmubc/download?ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\",\"download_location\":\"https://api.unsplash.com/photos/rJkfSLTmubc/download?ixid=MnwzMzIyMjF8MHwxfHJhbmRvbXx8fHx8fHx8fDE2NTM1MzU1ODk\"},\"categories\":[],\"likes\":4,\"liked_by_user\":false,\"current_user_collections\":[],\"sponsorship\":null,\"topic_submissions\":{\"business-work\":{\"status\":\"rejected\"}},\"user\":{\"id\":\"mDwNkKFZlm4\",\"updated_at\":\"2022-05-25T19:49:37-04:00\",\"username\":\"brianwangenheim\",\"name\":\"BrianWangenheim\",\"first_name\":\"Brian\",\"last_name\":\"Wangenheim\",\"twitter_username\":null,\"portfolio_url\":\"https://brianwangenheim.info/\",\"bio\":\"Hi!MynameisBrianWangenheim.Thesephotosarefreebutifyoucanpleasemakeadonation,itsupportswhatIdo!Thanks!😊📷👀🌪️\",\"location\":\"california,usa\",\"links\":{\"self\":\"https://api.unsplash.com/users/brianwangenheim\",\"html\":\"https://unsplash.com/@brianwangenheim\",\"photos\":\"https://api.unsplash.com/users/brianwangenheim/photos\",\"likes\":\"https://api.unsplash.com/users/brianwangenheim/likes\",\"portfolio\":\"https://api.unsplash.com/users/brianwangenheim/portfolio\",\"following\":\"https://api.unsplash.com/users/brianwangenheim/following\",\"followers\":\"https://api.unsplash.com/users/brianwangenheim/followers\"},\"profile_image\":{\"small\":\"https://images.unsplash.com/profile-1652314659498-a2b444f0d453image?ixlib=rb-1.2.1\\u0026crop=faces\\u0026fit=crop\\u0026w=32\\u0026h=32\",\"medium\":\"https://images.unsplash.com/profile-1652314659498-a2b444f0d453image?ixlib=rb-1.2.1\\u0026crop=faces\\u0026fit=crop\\u0026w=64\\u0026h=64\",\"large\":\"https://images.unsplash.com/profile-1652314659498-a2b444f0d453image?ixlib=rb-1.2.1\\u0026crop=faces\\u0026fit=crop\\u0026w=128\\u0026h=128\"},\"instagram_username\":null,\"total_collections\":6,\"total_likes\":0,\"total_photos\":552,\"accepted_tos\":true,\"for_hire\":true,\"social\":{\"instagram_username\":null,\"portfolio_url\":\"https://brianwangenheim.info/\",\"twitter_username\":null,\"paypal_email\":null}},\"exif\":{\"make\":null,\"model\":null,\"name\":null,\"exposure_time\":null,\"aperture\":null,\"focal_length\":null,\"iso\":null},\"location\":{\"title\":null,\"name\":null,\"city\":null,\"country\":null,\"position\":{\"latitude\":null,\"longitude\":null}},\"views\":160924,\"downloads\":1688}";
            Photo photo = JsonConvert.DeserializeObject<Photo>(data);

            // Act
            PhotoRepository repository = new PhotoRepository();
            PhotoModel model = repository.Mapper(photo);

            // Assert
            Assert.AreEqual(model.Id, "rJkfSLTmubc");
        }
    }
}