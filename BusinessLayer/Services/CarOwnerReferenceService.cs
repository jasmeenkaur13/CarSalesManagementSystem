using AutoMapper;
using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;
using System.Linq;

/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class CarOwnerReferenceService: ICarOwnerReferenceService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CarOwnerReferenceService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a owner
        /// </summary>
        /// <param name="ownerDTO"></param>
        /// <returns></returns>
        public int CreateCarOwnerReference(CarOwnerRefernceDTO carReferenceDTO)
        {
            var carReference = new Owners_Cars_Ref
            {
                CarId = carReferenceDTO.CarId,
                OwnerId = carReferenceDTO.OwnerId
            };
            _unitOfWork.CarOwnerRepository.Insert(carReference);
            _unitOfWork.Save();
            return carReference.Id;
           
        }

        /// <summary>
        /// Deletes a particular owner
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public bool DeleteCarOwnerReference(int carRefernceId)
        {
            var success = false;
            if (carRefernceId > 0)
            {
               var refernce = _unitOfWork.CarOwnerRepository.GetByID(carRefernceId);
                if (refernce != null)
                {

                    _unitOfWork.OwnerRepository.Delete(refernce);
                    _unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public CarOwnerRefernceDTO GetByCarID(int carId) {
            var carReference = _unitOfWork.CarOwnerRepository.GetMany(x => x.CarId == carId).FirstOrDefault();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Owners_Cars_Ref, CarOwnerRefernceDTO>();
            });
            IMapper mapper = config.CreateMapper();
            var carRefernceDTO = mapper.Map<Owners_Cars_Ref, CarOwnerRefernceDTO>(carReference);
            return carRefernceDTO;
        }
    }
}