using BusinessLayer;
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
    public class OwnerValidationService: IOwnerValidationService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string PrivateOwner = "P";
        /// <summary>
        /// 
        /// </summary>
        private readonly string Dealer = "D";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerDTO"></param>
        /// <returns></returns>
        public bool ValidateOwnerType(OwnerDTO ownerDTO) {
            bool isValid = true;
            if ((string.Equals(ownerDTO.OwnerType, Dealer, System.StringComparison.InvariantCultureIgnoreCase) && string.IsNullOrWhiteSpace(ownerDTO.DealerABN)) ||
                (string.Equals(ownerDTO.OwnerType, PrivateOwner, System.StringComparison.InvariantCultureIgnoreCase) && string.IsNullOrWhiteSpace(ownerDTO.Name) && string.IsNullOrWhiteSpace(ownerDTO.PhoneNumber))
                ) {
                isValid = false;
            }
            return isValid;

        }
    }
}