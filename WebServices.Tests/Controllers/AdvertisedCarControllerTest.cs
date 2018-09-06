
using BusinessLayer;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebServices.Controllers;

namespace WebServices.Tests.Controllers
{
    /// <summary>
    /// Test class to test methods of AdvertisedCarController
    /// </summary>
    [TestClass]
    public class AdvertisedCarControllerTest
    {
        #region Private Readonly vaiables
        private readonly IOwnerValidationService _ownerValidationService = new OwnerValidationService();
        private readonly GlobalLogger _logger = new GlobalLogger();
        #endregion

        #region Action Test Case
        /// <summary>
        /// Get the results from get request of API
        /// </summary>
        [TestMethod]
        public void Get()
        {
            var mockRepository = new Mock<IAdvertiseCarDetailsService>();
            mockRepository.Setup(x => x.GetListOfAdvertisedCars("2017", "1", "1"))
                .Returns(new List<AdvertisedCarDTO> { new AdvertisedCarDTO { ID = 1 } });

            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepository.Object, _ownerValidationService, _logger);
            var results = controller.Get("2017", "1", "1");
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(1, results.FirstOrDefault().ID);

        }

        /// <summary>
        /// Post the Advertise car details Object Successful
        /// </summary>
        [TestMethod]
        public void Post()
        {
            int a = 1;
           // bool yes = true;

            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
            var ab = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "2017",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "D",
                    Comments = "sample string 7",
                }
            };
            mockRepositorycar.Setup(x => x.CreateAdvertiseCarDetailsEntry(ab)).Returns(a);


            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(ab);
            string succesful;
            Assert.IsTrue(response.TryGetContentValue<string>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(succesful, "1 Inserted successfully");
        }

        /// <summary>
        /// Post With Incomplete Values Of Owner Type -- Private should have name and Phone number
        /// </summary>
        [TestMethod]
        public void PostWithIncomleteValuesForOwnerType()
        {

            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
            var ab = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "as",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "asd",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "P",
                    Comments = "sample string 7",
                }
            };

            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(ab);
            HttpError succesful;
            Assert.IsTrue(response.TryGetContentValue<HttpError>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Update the object of car details Successful
        /// </summary>
        [TestMethod]
        public void Put()
        {
            int a = 1;
            // bool yes = true;

            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
            var ab = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "2017",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "D",
                    Comments = "sample string 7",
                }
            };
            mockRepositorycar.Setup(x => x.UpdateAdvertiseCarDetailsEntry(a,ab)).Returns(true);


            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Put(a,ab);
            string succesful;
            Assert.IsTrue(response.TryGetContentValue<string>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(succesful, "Updated Successfully");
        }

        /// <summary>
        /// Put with invalid Owner type details combination -- Delaer should have dealer Number
        /// </summary>
        [TestMethod]
        public void PutWithIncomleteValuesForOwnerType()
        {
            int a = 1;
            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
            var ab = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "as",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "asd",
                    Email = "",
                    DealerABN = "",
                    OwnerType = "D",
                    Comments = "sample string 7",
                }
            };

            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Put(a,ab);
            HttpError succesful;
            Assert.IsTrue(response.TryGetContentValue<HttpError>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Update with Invalid Id
        /// </summary>
        [TestMethod]
        public void PutWithInvalidId()
        {
            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
            var ab = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "as",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "asd",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "P",
                    Comments = "sample string 7",
                }
            };

            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Put(0, ab);
            HttpError succesful;
            Assert.IsTrue(response.TryGetContentValue<HttpError>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Delete the Advertise Car
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            int a = 1;

            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
            mockRepositorycar.Setup(x => x.DeleteAdvertiseCarDetailsEntry(a)).Returns(true);


            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Delete(a);
            string succesful;
            Assert.IsTrue(response.TryGetContentValue<string>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(succesful, "Deleted succesfully");
        }

        /// <summary>
        /// Delete the advertised car with Id
        /// </summary>
        [TestMethod]
        public void DeleteWithInvalidId()
        {
            var mockRepositorycar = new Mock<IAdvertiseCarDetailsService>();
           
            // Arrange
            AdvertisedCarController controller = new AdvertisedCarController(mockRepositorycar.Object, _ownerValidationService, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Delete(0);
            HttpError succesful;
            Assert.IsTrue(response.TryGetContentValue<HttpError>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
        #endregion


    }
}
