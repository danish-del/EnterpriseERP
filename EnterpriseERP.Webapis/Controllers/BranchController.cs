using Azure.Core;
using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Branch;
using EnterpriseERP.Application.Response;
using EnterpriseERP.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseERP.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _service;
        private readonly ILogger<BranchController> _logger;
        public BranchController(IBranchService Service, ILogger<BranchController> logger)
        {
            _service = Service;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ResponseBranchDto>>.SuccessResponse(res,
                "Data fetched Successfully!"));
        }
        [HttpGet("Paged")]
        public async Task<IActionResult> GetPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            var res = await _service.GetPagedAsync(pageNumber, pageSize);
            return Ok(ApiResponse<PagedResult<ResponseBranchDto>>.SuccessResponse(res,
                "Data fetched Successfully!"));
        }

       [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return Ok(ApiResponse<ResponseBranchDto>.SuccessResponse(res,
                "Data retrieved Sucecssfully!"));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBranchDto dto)
        {
            _logger.LogInformation("Create Branch");
             await _service.CreateAsync(dto);
            _logger.LogInformation("Branch Created Successfully!");
            return Ok(ApiResponse<ResponseBranchDto?>.SuccessResponse(null,
                "Created Branch Successfully!"));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,UpdateBranchDto dto)
        {
            _logger.LogInformation("Updating Branch with ID {BranchId}", id);
              await _service.UpdateAsync(id, dto);
            _logger.LogInformation("Branch with ID : {BranchId} Updated Successfully!",id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Updated Branch Successfully!"));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting Branch with ID {BranchId}", id);
            await _service.DeleteAsync(id);
            _logger.LogInformation("Branch with ID : {BranchId} Deleted Successfully!", id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Deleted Branch Successfully!"));
        }
    }
}
