using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Department;
using EnterpriseERP.Application.Response;
using EnterpriseERP.Application.Service;
using EnterpriseERP.Webapi.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseERP.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public DepartmentController(IDepartmentService DepartmentService,
            ILogger<GlobalExceptionHandler> Logger)
        {
            _departmentService = DepartmentService;
            _logger = Logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _departmentService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ResponseDepartmentDto>>.SuccessResponse(res,
                "Data Retreived Successfully!"));
        }
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(int pageNumber = 1, int pageSize =10)
        {
            var res = await _departmentService.GetPagedAsync(pageNumber, pageSize);
            return Ok(ApiResponse<PagedResult<ResponseDepartmentDto>>.SuccessResponse(res,
                "Data Retrieved Successfully!"));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _departmentService.GetByIdAsync(id);
            return Ok(ApiResponse<ResponseDepartmentDto>.SuccessResponse(res,
                "Data Retrieved Successfully"));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateDepartmentDto dto)
        {
            _logger.LogInformation("Create Department");
             await _departmentService.AddAsync(dto);
            _logger.LogInformation("Department Created Successfully!");
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Data Created Successfully!"));    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateDepartmentDto dto)
        {
            _logger.LogInformation($" Updating Department with ID {id}");
            await _departmentService.UpdateDepartmentDto(id, dto);
            _logger.LogInformation($"Department with ID {id} Updated Successfully!"); 
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Data updated Successfully"));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation($"Deleting Department with ID {id}");
            await _departmentService.DeleteAsync(id);
            _logger.LogInformation($"Department with Id {id} Deleted Successfully!");
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Data Deleted Successfully!"));
        }
    }
}
