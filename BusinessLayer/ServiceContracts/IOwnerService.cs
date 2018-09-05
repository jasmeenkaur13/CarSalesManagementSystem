using DataTransferObjects;
/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    public interface IOwnerService
    {
        int CreateOwner(OwnerDTO ownerDTO);
        bool UpdateOwner(int ownerId, OwnerDTO ownerDTO);
        bool DeleteOwner(int ownerId);
    }
}
