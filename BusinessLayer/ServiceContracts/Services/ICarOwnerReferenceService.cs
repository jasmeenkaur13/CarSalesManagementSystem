using DataTransferObjects;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICarOwnerReferenceService
    {
        int CreateCarOwnerReference(CarOwnerRefernceDTO carReferenceDTO);
        bool DeleteCarOwnerReference(int carRefernceId);
        CarOwnerRefernceDTO GetByCarID(int carId);
    }
}
