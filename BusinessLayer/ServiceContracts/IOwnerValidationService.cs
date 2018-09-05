using DataTransferObjects;

namespace BusinessLayer
{
    public interface IOwnerValidationService
    {
        bool ValidateOwnerType(OwnerDTO ownerDTO);
    }
}
