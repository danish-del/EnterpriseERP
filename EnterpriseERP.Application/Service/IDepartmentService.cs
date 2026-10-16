using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Application.Service
{
    public interface IDepartmentService
    {
        Task<IEnumerable<ResponseDepartmentDto>> GetAllAsync();
        Task<PagedResult<ResponseDepartmentDto>> GetPagedAsync(int pageNumber, int pageSize);
        Task<ResponseDepartmentDto> GetByIdAsync(int id);
        Task AddAsync(CreateDepartmentDto dto);
        Task<bool> UpdateDepartmentDto(int id, UpdateDepartmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
