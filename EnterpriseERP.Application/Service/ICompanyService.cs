using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Company;
using EnterpriseERP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.Service
{
    public interface ICompanyService
    {
        Task<IEnumerable<ResponseComapnyDto>> GetAllAsync();
        Task<PagedResult<ResponseComapnyDto>> GetPagedAsync(int pageNumber, int pageSize);
        Task<ResponseComapnyDto?> GetByIdAsync(int id);
        Task AddAsync(CreateCompanyDto dto);
        Task<bool> UpdateAsync(int id, UpdateComapnyDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
