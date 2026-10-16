using AutoMapper;
using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Branch;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Application.Service;
using EnterpriseERP.Domain.Model;

namespace EnterpriseERP.Insfrastructure.Implementation
{
    public class BranchService : IBranchService
    {
        private readonly IGenericRepository<Branch> _branchRepository;
        private readonly IMapper _mapper;
        public BranchService(IGenericRepository<Branch> Branch, IMapper mapper)
        {
            _branchRepository = Branch;
            _mapper = mapper;
        }
        public async Task<PagedResult<ResponseBranchDto>> GetPagedAsync(int pageNumber,int pageSize)
        {
            var res = await _branchRepository.GetPagedAsync(pageNumber, pageSize);
            return new PagedResult<ResponseBranchDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseBranchDto>>(res.Items),
                TotalCount = res.TotalCount,
                PageNumber = res.PageNumber,
                PageSize = pageSize
            };
        }
        public async Task<IEnumerable<ResponseBranchDto>> GetAllAsync()
        {
            var entity = await _branchRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseBranchDto>>(entity);
        }
        public async Task<ResponseBranchDto> GetByIdAsync(int id)
        {
            var entity = await _branchRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Branch with Id {id} not found!");
            return _mapper.Map<ResponseBranchDto>(entity);
        }
        public async Task CreateAsync(CreateBranchDto dto)
        {
            var entity = _mapper.Map<Branch>(dto);
            await _branchRepository.AddAsync(entity);
        }
        public async Task<bool> UpdateAsync(int id, UpdateBranchDto dto)
        {
            var entity = await _branchRepository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception($"Branch with Id {id} not found!");
            _mapper.Map(dto, entity);
            await _branchRepository.UpdateAsync(entity);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _branchRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Branch with Id{id} not found!");
            await _branchRepository.DeleteAsync(id);
            return true;
        }
    }
}



