using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Services
{
    public class DiscountModeService : IDiscountModeService
    {
        private readonly IDiscountModeRepository _discountModeRepository;
        public DiscountModeService(IDiscountModeRepository discountModeRepository)
        {
            _discountModeRepository = discountModeRepository;
        }
        public async Task<GetDiscountModeDTO> CreateDiscountModeAsync(CreateDiscountModeDTO discountModeDTO)
        {
            try
            {
                if (discountModeDTO == null) throw new ArgumentNullException(nameof(discountModeDTO));
                var discountMode = new DiscountMode()
                {
                    IsDiscountInPercentage = discountModeDTO.IsDiscountInPercentage,
                };
                var result = await _discountModeRepository.CreateAsync(discountMode);
                var newDiscoutModeDTO = new GetDiscountModeDTO(result.DiscountModeId, result.IsDiscountInPercentage);
                return newDiscoutModeDTO;
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error occurred in CreateDiscountModeAsync: {ex.Message}");
                throw;
            }
        }


        public async Task<bool> DeleteDiscountModeAsync(long Id)
        {
            try
            {
                if (Id < 0) throw new ArgumentOutOfRangeException(nameof(Id));
                var discountMode = await _discountModeRepository.GetAsyncById(Id);
                return await _discountModeRepository.DeleteAsync(discountMode);
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error occurred in DeleteDiscountModeAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<GetDiscountModeDTO> GetDiscountModeByIdAsync(long id)
        {
            try
            {
                var discountMode = await _discountModeRepository.GetAsyncById(id);
                if (discountMode != null)
                {
                    return new GetDiscountModeDTO(discountMode.DiscountModeId, discountMode.IsDiscountInPercentage);
                }
                return null;
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error occurred in GetDiscountModeByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<GetDiscountModeDTO>> GetDiscountModesAsync()
        {
            try
            {
                var discountModeList = await _discountModeRepository.GetAsyncAll();
                if (discountModeList != null)
                {
                    var discountModeDTOList = discountModeList.Select(discountMode => new GetDiscountModeDTO(discountMode.DiscountModeId, discountMode.IsDiscountInPercentage));
                    return discountModeDTOList;
                }
                return null;
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error occurred in GetDiscountModesAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<GetDiscountModeDTO> UpdateDiscountModeAsync(long Id, UpdateDiscountModeDTO discountModeDTO)
        {
            try
            {
                var oldDiscountMode = await _discountModeRepository.GetAsyncById(Id);
                if (oldDiscountMode != null)
                {
                    oldDiscountMode.IsDiscountInPercentage = discountModeDTO.IsDiscountInPercentage;

                    var discountMode = await _discountModeRepository.UpdateAsync(oldDiscountMode);
                    return new GetDiscountModeDTO(discountMode.DiscountModeId, discountMode.IsDiscountInPercentage);
                }
                return null;
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error occurred in UpdateDiscountModeAsync: {ex.Message}");
                throw;
            }
        }

      
    }
}
