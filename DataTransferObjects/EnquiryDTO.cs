using System.ComponentModel.DataAnnotations;
/// <summary>
/// 
/// </summary>
namespace DataTransferObjects
{
    /// <summary>
    /// DTO holds the details of the Owner of the car
    /// </summary>
    public class EnquiryDTO
    {
        /// <summary>
        /// Id of the enquiry made
        /// </summary>
        public int EnquiryId { get; set; }
        /// <summary>
        /// Id of Car for which enquiry is made
        /// </summary>
        [Required(ErrorMessage = "Car Id is required")]
        public int CarId { get; set; }
        /// <summary>
        /// Name of the person who enquired
        /// </summary>
        [RegularExpression("^[A-Za-z\\s]+$", ErrorMessage = "Not a valid name")]
        public string Name { get; set; }
        /// <summary>
        /// Phone Number of the person who enquired
        /// </summary>
        [Phone(ErrorMessage = "Please enter a valid value")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email Id of the person who enquired
        /// </summary>
        [EmailAddress(ErrorMessage = "Please Enter a valid value")]
        public string Email { get; set; }
    }
}
