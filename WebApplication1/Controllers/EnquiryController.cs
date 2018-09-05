using BusinessLayer;
using DataTransferObjects;
using System.Net.Http;
using System.Web.Http;

/// <summary>
/// 
/// </summary>
namespace WebServices.Controllers
{
    /// <summary>
    /// Enquiry Controller
    /// </summary>
    public class EnquiryController : ApiController
    {
        /// <summary>
        /// Enquiry Service property
        /// </summary>
        private readonly IEnquiryService _enquiryService;

        /// <summary>
        /// Public constructor to initialize enquiry service instance
        /// </summary>
        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        /// <summary>
        /// Inserts the new Enquiry
        /// </summary>
        /// <param name="enquiryDTO"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]EnquiryDTO enquiryDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, _enquiryService.CreateEnquiry(enquiryDTO).ToString() + " Inserted successfully");
            }
        }
    }
}
