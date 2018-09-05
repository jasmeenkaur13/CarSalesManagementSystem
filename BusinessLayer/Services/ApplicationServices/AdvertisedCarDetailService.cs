using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvertisedCarDetailService : IAdvertiseCarDetailsService
    {
        private readonly IOwnerService _ownerService;
        private readonly IAdvertiseCarService _advertiseCarService;
        private readonly ICarOwnerReferenceService _carOwnerReferenceService;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public AdvertisedCarDetailService(IOwnerService ownerService, IAdvertiseCarService advertiseCarService, ICarOwnerReferenceService carOwnerReferenceService)
        {
            _ownerService = ownerService;
            _advertiseCarService = advertiseCarService;
            _carOwnerReferenceService = carOwnerReferenceService;
        }

        /// <summary>
        /// Creates a car entry
        /// </summary>
        /// <param name="advertiseCarDTO"></param>
        /// <returns></returns>
        public int CreateAdvertiseCarDetailsEntry(AdvertisedCarDetailsDTO advertiseCarDTO)
        {
            int ownerId = _ownerService.CreateOwner(advertiseCarDTO.OwnerDetails);
            int carId =_advertiseCarService.CreateAdvertiseCar(advertiseCarDTO.CarDetails);
            CarOwnerRefernceDTO refernce = new CarOwnerRefernceDTO
            {
                CarId = carId,
                OwnerId = ownerId
            };
            _carOwnerReferenceService.CreateCarOwnerReference(refernce);
            return carId;
        }

        /// <summary>
        /// Updates a car
        /// </summary>
        /// <param name="advertiseCarId"></param>
        /// <param name="advertiseCarDTO"></param>
        /// <returns></returns>
        public bool UpdateAdvertiseCarDetailsEntry(int advertiseCarId, AdvertisedCarDetailsDTO advertiseCarDTO)
        {
            var success = false;
            if (advertiseCarDTO != null)
            {
                var carReference = _carOwnerReferenceService.GetByCarID(advertiseCarId);
                if (advertiseCarDTO.CarDetails != null)
                {
                    _advertiseCarService.UpdateAdvertiseCar(advertiseCarId, advertiseCarDTO.CarDetails);
                    success = true;
                }
                if (advertiseCarDTO.OwnerDetails != null)
                {
                    _ownerService.UpdateOwner(carReference.OwnerId, advertiseCarDTO.OwnerDetails);
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular car
        /// </summary>
        /// <param name="advertiseCarId"></param>
        /// <returns></returns>
        public bool DeleteAdvertiseCarDetailsEntry(int advertiseCarId)
        {
            var success = false;
            if (advertiseCarId != 0)
            {
                var carReference = _carOwnerReferenceService.GetByCarID(advertiseCarId);
                _advertiseCarService.DeleteAdvertiseCar(advertiseCarId);
                if (carReference != null)
                {
                    _ownerService.DeleteOwner(carReference.OwnerId);
                    _carOwnerReferenceService.DeleteCarOwnerReference(carReference.Id);
                }
                success = true;
               
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="make"></param>
        /// <param name="year"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<AdvertisedCarDTO> GetListOfAdvertisedCars(string make, string year, string model) {
            return _advertiseCarService.GetListOfAdvertisedCars(make, year, model);
        }
    }
}