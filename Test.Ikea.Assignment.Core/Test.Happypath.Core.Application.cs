namespace Test.Ikea.Assignment.Core
{
    using System;
    using System.Threading.Tasks;
    using IkeaAssignmentCore;
    using IkeaAssignmentCore.Application;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Test.Ikea.Assignment.Core.Repositories;

    [TestClass]
    public class HappypathUnitTestCore
    {
        [TestMethod]
        public async Task TestGetPhoto()
        {
            // Arrange
            PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

            // Act
            var photo = await service.GetPhotoAsync();

            // Assert
            Assert.AreEqual(photo.Id, "rJkfSLTmubc");
        }

        [TestMethod]
        public async Task TestGetPhotoStatisticsChangeDefaultDays()
        {
            // Arrange
            PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

            // Act
            var photo = await service.GetPhotoAsync();
            var statictics = await service.GetPhotoStatisticsAsync(photo, string.Empty);

            // Assert
            Assert.AreEqual(statictics.PastDaysDownloads, 2216);
        }

        [TestMethod]
        public async Task TestGetPhotoStatisticsPercentageDefaultDays()
        {
            // Arrange
            PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

            // Act
            var photo = await service.GetPhotoAsync();
            var statictics = await service.GetPhotoStatisticsAsync(photo, string.Empty);

            // Assert
            Assert.AreEqual(Math.Round(statictics.PercentagePastDaysDownloads), 100);
        }

        [TestMethod]
        public async Task TestGetPhotoStatisticsChangeTenDays()
        {
            // Arrange
            PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

            // Act
            var photo = await service.GetPhotoAsync();
            var statictics = await service.GetPhotoStatisticsAsync(photo, "10");

            // Assert
            Assert.AreEqual(statictics.PastDaysDownloads, 661);
        }

        [TestMethod]
        public async Task TestGetPhotoStatisticsPercentageTenDays()
        {
            // Arrange
            PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

            // Act
            var photo = await service.GetPhotoAsync();
            var statictics = await service.GetPhotoStatisticsAsync(photo, "10");

            // Assert
            Assert.AreEqual(Math.Round(statictics.PercentagePastDaysDownloads), 39);
        }

        [TestMethod]
        public async Task TestSavePhoto()
        {
            // Arrange
            PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

            // Act
            var photo = await service.GetPhotoAsync();
            var statictics = await service.GetPhotoStatisticsAsync(photo, string.Empty);
            var result = await service.SavePhotoAsync(statictics);

            // Assert
            Assert.AreEqual(result, true);
        }
    }
}
