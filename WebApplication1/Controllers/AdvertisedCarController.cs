using BusinessLayer;
using DataTransferObjects;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class AdvertisedCarController : ApiController
    {
        private readonly IAdvertiseCarDetailsService _advertiseCarDetailsService;

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AdvertisedCarController(IAdvertiseCarDetailsService advertiseCarDetailsService)
        {
            _advertiseCarDetailsService = advertiseCarDetailsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get(string make, string year, string model)
        {
             
        }

        /// <summary>
        /// 
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
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, _advertiseCarDetailsService.CreateAdvertiseCarDetailsEntry(carDetailsDTO).ToString() + " Inserted successfully");
            }
        }

        /// <summary>
        /// 
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
                    if (_advertiseCarDetailsService.UpdateAdvertiseCarDetailsEntry(id, carDetailsDTO))
                    {
                        return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Updated Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Some Error Occured");
                    }
                }
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "Id does not exist");
            }
        }

        /// <summary>
        /// 
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
