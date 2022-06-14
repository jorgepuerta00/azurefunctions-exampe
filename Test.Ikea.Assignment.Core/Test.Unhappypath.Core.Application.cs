namespace Test.Ikea.Assignment.Core
{
    using System;
    using System.Threading.Tasks;
    using IkeaAssignmentCore;
    using IkeaAssignmentCore.Application;
    using IkeaAssignmentCore.Application.Common.HttpClientHandler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Test.Ikea.Assignment.Core.Repositories;

    [TestClass]
    public class UnhappypathUnitTestCore
    {
        [TestMethod]
        public async Task TestUnsplashUrlThrowError()
        {
            try
            {
                // Arrange
                PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration("local.unhappy.settings.json"));

                // Act
                await service.GetPhotoAsync();
            }
            catch (Exception error)
            {
                // Assert
                Assert.AreEqual(error.Message, "Value cannot be null. (Parameter 'Unsplash Url is null')");
            }
        }

        [TestMethod]
        public async Task TestPhotoModelThrowError()
        {
            try
            {
                // Arrange
                PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

                // Act
                await service.GetPhotoStatisticsAsync(null, string.Empty);
            }
            catch (Exception error)
            {
                // Assert
                Assert.AreEqual(error.Message, "Value cannot be null. (Parameter 'photoModel is null')");
            }
        }
        [TestMethod]
        public async Task TestUnsplashStatisticsUrlThrowError()
        {
            try
            {
                // Arrange
                PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration("unhappypath.statistics.settings.json"));

                // Act
                await service.GetPhotoAsync();
            }
            catch (Exception error)
            {
                // Assert
                Assert.AreEqual(error.Message, "Value cannot be null. (Parameter 'Unsplash Url Statistics is null')");
            }
        }


        [TestMethod]
        public async Task TestConnectionRefuseThrowError()
        {
            try
            {
                // Arrange
                PhotoService service = new PhotoService(new HttpClientHandler(), new MockPhotoRepository(), new AppConfiguration("unhappypath.url.settings.json"));

                // Act
                await service.GetPhotoAsync();
            }
            catch (Exception error)
            {
                // Assert
                Assert.AreEqual(error.Message, "Connection refused");
            }
        }

        [TestMethod]
        public async Task TestSavePhotoThrowError()
        {
            try
            {
                // Arrange
                PhotoService service = new PhotoService(new MockHttpClientHandler(), new MockPhotoRepository(), new AppConfiguration());

                // Act
                await service.SavePhotoAsync(null);
            }
            catch (Exception error)
            {
                // Assert
                Assert.AreEqual(error.Message, "Value cannot be null. (Parameter 'photoModel is null')");
            }
        }
    }
}
