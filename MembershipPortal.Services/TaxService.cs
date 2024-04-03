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
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;
        public async Task<GetTaxDTO> CreateTaxAsync(CreateTaxDTO taxDTO)
        {
            try
            {
                if (taxDTO == null) throw new ArgumentNullException(nameof(taxDTO));
                var tax = new Tax()
                {
                    SGST = taxDTO.SGST,
                    CGST = taxDTO.CGST,
                };
                var result = await _taxRepository.CreateAsync(tax);
                var newTaxDTO = new GetTaxDTO(result.Id, result.CGST, result.SGST);
                return newTaxDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTaxAsync(long Id)
        {
            try
            {
                var tax = await _taxRepository.GetAsyncById(Id);
                var result = await _taxRepository.DeleteAsync(tax);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetTaxDTO> GetTaxByIdAsync(long id)
        {
            try
            {
                var tax = await _taxRepository.GetAsyncById(id);
                if (tax != null)
                {
                    return new GetTaxDTO(tax.Id, tax.SGST, tax.CGST);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetTaxDTO>> GetTaxesAsync()
        {
            try
            {
                var taxList = await _taxRepository.GetAsyncAll();
                if (taxList != null)
                {
                    var taxDTOList = taxList.Select(tax => new GetTaxDTO(tax.Id, tax.SGST, tax.CGST));
                    return taxDTOList;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetTaxDTO> UpdateTaxAsync(long Id, UpdateTaxDTO taxDTO)
        {
            var oldTax = await _taxRepository.GetAsyncById(Id);
            if (oldTax != null)
            {
                oldTax.SGST = taxDTO.SGST;
                oldTax.CGST = taxDTO.CGST;
                await _taxRepository.UpdateAsync(oldTax);
                return new GetTaxDTO(oldTax.Id, oldTax.SGST, oldTax.CGST);
            }
            return null;
        }
    }
}
