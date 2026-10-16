using AutoMapper;
using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Company;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Application.Service;
using EnterpriseERP.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseERP.Insfrastructure.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(IGenericRepository<Company> Company , IMapper mapper)
        {
            _companyRepository = Company;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseComapnyDto>> GetAllAsync()
        {
            var entity = await _companyRepository.GetAllAsync();
            return  _mapper.Map<IEnumerable<ResponseComapnyDto>>(entity);
        }
        public async Task<PagedResult<ResponseComapnyDto>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var entity = await _companyRepository.GetPagedAsync(pageNumber,pageSize);
            return new PagedResult<ResponseComapnyDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseComapnyDto>>(entity.Items),
                TotalCount = entity.TotalCount,
                PageNumber = entity.PageNumber,
                PageSize = entity.PageSize
            };
        }
        public async Task<ResponseComapnyDto?> GetByIdAsync(int id)
        {
            var entity = await _companyRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Comapny with Id {id} not found!");
            return _mapper.Map<ResponseComapnyDto>(entity);
        }
        public async Task AddAsync(CreateCompanyDto dto)
        {
            var entity = _mapper.Map<Company>(dto);
            await _companyRepository.AddAsync(entity);
        }
        public async Task<bool> UpdateAsync(int id,UpdateComapnyDto dto)
        {
            var entity = await _companyRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Comapny with Id {id} not found!");
            _mapper.Map(entity,dto);
            await _companyRepository.UpdateAsync(entity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           var res = await _companyRepository.GetByIdAsync(id);
            if (res == null)
                throw new KeyNotFoundException($"Comapany with Id {id} not found!");
            await _companyRepository.DeleteAsync(id);
            return true;
        }
    }
}
