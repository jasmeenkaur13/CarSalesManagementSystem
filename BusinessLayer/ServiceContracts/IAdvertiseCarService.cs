using DataTransferObjects;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    interface IAdvertiseCarService
    {
        int CreateAdvertiseCar(AdvertisedCarDTO advertiseCarDTO);
        bool UpdateAdvertiseCar(int advertiseCarId, AdvertisedCarDTO advertiseCarDTO);
        bool DeleteAdvertiseCar(int advertiseCarId);
    }
}
