using DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdvertiseCarService
    {
        int CreateAdvertiseCar(AdvertisedCarDTO advertiseCarDTO);
        bool UpdateAdvertiseCar(int advertiseCarId, AdvertisedCarDTO advertiseCarDTO);
        bool DeleteAdvertiseCar(int advertiseCarId);
        IList<AdvertisedCarDTO> GetListOfAdvertisedCars(string make, string year, string model);
    }
}
