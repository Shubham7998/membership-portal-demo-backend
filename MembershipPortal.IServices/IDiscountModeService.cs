using MembershipPortal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IServices
{
    public interface IDiscountModeService
    {
        Task<IEnumerable<GetDiscountModeDTO>> GetDiscountModesAsync();
        Task<GetDiscountModeDTO> GetDiscountModeByIdAsync(long id);
        Task<GetDiscountModeDTO> CreateDiscountModeAsync(CreateDiscountModeDTO discoutModeDTO);
        Task<GetDiscountModeDTO> UpdateDiscountModeAsync(long Id, UpdateDiscountModeDTO discoutModeDTO);
        Task<bool> DeleteDiscountModeAsync(long Id);
    }
}
