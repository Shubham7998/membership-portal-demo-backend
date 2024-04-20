using MembershipPortal.DTOs;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IServices
{
    public interface ITaxService
    {
        Task<IEnumerable<GetTaxDTO>> GetTaxesAsync();
        Task<GetTaxDTO> GetTaxByIdAsync(long id);
        Task<GetTaxDTO> CreateTaxAsync(CreateTaxDTO taxDTO);
        Task<GetTaxDTO> UpdateTaxAsync(long Id, UpdateTaxDTO taxDTO);
        Task<bool> DeleteTaxAsync(long Id);

        


        public Task<(IEnumerable<GetTaxDTO>, int)> GetAllPaginatedAndSortedTaxAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Tax taxObj);


    }
}
