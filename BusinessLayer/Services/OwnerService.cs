using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OwnerService: IOwnerService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public OwnerService()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Creates a owner
        /// </summary>
        /// <param name="ownerDTO"></param>
        /// <returns></returns>
        public int CreateOwner(OwnerDTO ownerDTO)
        {
           var owner = new Owner
                {
                    Comments = ownerDTO.Comments,
                    Name = ownerDTO.Name,
                    Email = ownerDTO.Email,
                    PhoneNumber = ownerDTO.PhoneNumber,
                    DealerABN = ownerDTO.DealerABN,
                    OwnerType = ownerDTO.OwnerType
                };
            _unitOfWork.OwnerRepository.Insert(owner);
            _unitOfWork.Save();
            return owner.Id;
           
        }

        /// <summary>
        /// Updates a owner
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="OwnerDTO"></param>
        /// <returns></returns>
        public bool UpdateOwner(int ownerId, OwnerDTO ownerDTO)
        {
            var success = false;
            if (ownerDTO != null)
            {
            
                var owner = _unitOfWork.OwnerRepository.GetByID(ownerId);
                if (owner != null)
                {
                    owner.OwnerType = ownerDTO.OwnerType;
                    _unitOfWork.OwnerRepository.Update(owner);
                    _unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular owner
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public bool DeleteOwner(int ownerId)
        {
            var success = false;
            if (ownerId > 0)
            {
               var owner = _unitOfWork.OwnerRepository.GetByID(ownerId);
                if (owner != null)
                {

                    _unitOfWork.OwnerRepository.Delete(owner);
                    _unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}