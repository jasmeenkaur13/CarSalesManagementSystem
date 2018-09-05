using BusinessLayer;
using DataTransferObjects;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

/// <summary>
/// 
/// </summary>
namespace WebServices.Controllers
{
    /// <summary>
    /// Car Details controller
    /// </summary>
    public class AdvertisedCarController : ApiController
    {
        private readonly IAdvertiseCarDetailsService _advertiseCarDetailsService;
        private readonly IOwnerValidationService _ownerValidationService;

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AdvertisedCarController(IAdvertiseCarDetailsService advertiseCarDetailsService, IOwnerValidationService ownerValidationService)
        {
            _advertiseCarDetailsService = advertiseCarDetailsService;
            _ownerValidationService = ownerValidationService;

        }

        /// <summary>
        /// fetched the list of cars advertised
        /// </summary>
        /// <returns></returns>
        public IList<AdvertisedCarDTO> Get(string make, string year, string model)
        {
            var cars = _advertiseCarDetailsService.GetListOfAdvertisedCars(make, year, model);
            return cars;

        }

        /// <summary>
        /// Insert the car details
        /// </summary>
        /// <param name="carDetailsDTO"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]AdvertisedCarDetailsDTO carDetailsDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                if (_ownerValidationService.ValidateOwnerType(carDetailsDTO.OwnerDetails))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, _advertiseCarDetailsService.CreateAdvertiseCarDetailsEntry(carDetailsDTO).ToString() + " Inserted successfully");
                }
                else
                {
                    return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "Incompleted details for the owner type");
                }
            }
        }

        /// <summary>
        /// Update the car details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carDetailsDTO"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, [FromBody]AdvertisedCarDetailsDTO carDetailsDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                if (id > 0)
                {
                    if (_ownerValidationService.ValidateOwnerType(carDetailsDTO.OwnerDetails))
                    {
                        if (_advertiseCarDetailsService.UpdateAdvertiseCarDetailsEntry(id, carDetailsDTO))
                        {
                            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully");
                        }
                        else
                        {
                            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Some Error Occured");
                        }
                    }
                    else
                    {
                        return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "Incompleted details for the owner type");
                    }
                }
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "Id does not exist");
            }
        }

        /// <summary>
        /// Delete the Car details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            if (id > 0)
            {
                if (_advertiseCarDetailsService.DeleteAdvertiseCarDetailsEntry(id))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Deleted succesfully");
                }
                else { return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Some Error Occured"); }
            }
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "Id does not exist");
        }
    }
}
