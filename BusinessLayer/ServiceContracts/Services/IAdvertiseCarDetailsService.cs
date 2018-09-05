using DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdvertiseCarDetailsService
    {
        int CreateAdvertiseCarDetailsEntry(AdvertisedCarDetailsDTO advertiseCarDTO);
        bool UpdateAdvertiseCarDetailsEntry(int advertiseCarId, AdvertisedCarDetailsDTO advertiseCarDTO);
        bool DeleteAdvertiseCarDetailsEntry(int advertiseCarId);
        IList<AdvertisedCarDTO> GetListOfAdvertisedCars(string make, string year, string model);
    }
}
