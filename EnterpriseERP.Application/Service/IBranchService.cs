using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Branch;
using EnterpriseERP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.Service
{
    public interface IBranchService
    {
        Task<IEnumerable<ResponseBranchDto>> GetAllAsync();
        Task<PagedResult<ResponseBranchDto>> GetPagedAsync(int pageNumber, int pageSize);
        Task<ResponseBranchDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBranchDto dto);
        Task<bool> UpdateAsync(int id, UpdateBranchDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
