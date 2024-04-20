using MembershipPortal.DTOs;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MembershipPortal.DTOs.ProductDTO;

namespace MembershipPortal.IServices
{
    public interface IGenderService
    {
        Task<GetGenderDTO> GetGenderAsync(long id);

        Task<IEnumerable<GetGenderDTO>> GetGendersAsync();
        Task<GetGenderDTO> UpdateGenderAsync(long id, UpdateGenderDTO genderDTO);
        Task<GetGenderDTO> CreateGenderAsync(CreateGenderDTO genderDTO);

        Task<bool> DeleteGenderAsync(long id);

       

        public Task<(IEnumerable<GetGenderDTO>, int)> GetAllPaginatedAndSortedGenderAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Gender genderObj);


    }
}
