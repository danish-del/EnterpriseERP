using AutoMapper;
using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Department;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Application.Service;
using EnterpriseERP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Insfrastructure.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _departmentRepo;
        private readonly IMapper _mapper;
        public DepartmentService(IGenericRepository<Department> DepartmentRepo,IMapper
            Mapper)
        {
            _departmentRepo = DepartmentRepo;
            _mapper = Mapper;
        }
        public async Task<IEnumerable<ResponseDepartmentDto>> GetAllAsync()
        {
            var entity = await _departmentRepo.GetAllAsync();
            return  _mapper.Map<IEnumerable<ResponseDepartmentDto>>(entity);
        }
        public async Task<PagedResult<ResponseDepartmentDto>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var entity = await _departmentRepo.GetPagedAsync(pageNumber, pageSize);
            return new PagedResult<ResponseDepartmentDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseDepartmentDto>>(entity.Items),
                TotalCount = entity.TotalCount,
                PageNumber = entity.PageNumber,
                PageSize = entity.PageSize
            };
        }
        public async Task<ResponseDepartmentDto> GetByIdAsync(int id)
        {
            var entity = await _departmentRepo.GetByIdAsync(id);
            return  _mapper.Map<ResponseDepartmentDto>(entity);
        }
        public async Task AddAsync(CreateDepartmentDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            await _departmentRepo.AddAsync(entity);
        }
        
        public async Task<bool> UpdateDepartmentDto(int id, UpdateDepartmentDto dto)
        {
            var entity = await _departmentRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Department with Id {id} not found!");
            _mapper.Map(dto,entity);
            await _departmentRepo.UpdateAsync(entity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _departmentRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Department with Id{id} not found!");
            await _departmentRepo.DeleteAsync(id);
            return true;

        }
    }
}
