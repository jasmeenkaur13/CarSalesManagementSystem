using DataTransferObjects;
/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    public interface IEnquiryService
    {
        int CreateEnquiry(EnquiryDTO enquiryDTO);
    }
}
