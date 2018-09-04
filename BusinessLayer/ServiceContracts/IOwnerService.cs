using DataTransferObjects;
/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    interface IOwnerService
    {
        int CreateOwner(OwnerDTO ownerDTO);
        bool UpdateOwner(int ownerId, OwnerDTO ownerDTO);
        bool DeleteOwner(int ownerId);
    }
}
