using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;

/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class EnquiryService: IEnquiryService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public EnquiryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates an enquiry
        /// </summary>
        /// <param name="enquiryDTO"></param>
        /// <returns></returns>
        public int CreateEnquiry(EnquiryDTO enquiryDTO)
        {
           var enquiry = new Enquiry
                {
                    CarId = enquiryDTO.CarId,
                    Name = enquiryDTO.Name,
                    Email = enquiryDTO.Email,
                    PhoneNumber = enquiryDTO.PhoneNumber
                };
            _unitOfWork.EnquiryRepository.Insert(enquiry);
            _unitOfWork.Save();
            return enquiry.EnquiryId;
           
        }
    }
}