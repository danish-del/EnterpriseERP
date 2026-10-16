using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.DTO.Company;
using EnterpriseERP.Application.Response;
using EnterpriseERP.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseERP.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(ICompanyService CompanyService,ILogger<CompanyController> logger)
        {
            _companyService = CompanyService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _companyService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ResponseComapnyDto>>.SuccessResponse(res,
                "Data fetched Successfully!"));
        }
        [HttpGet("Paged")]
        public async Task<IActionResult> GetPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            var res = await _companyService.GetPagedAsync(pageNumber, pageSize);
            return Ok(ApiResponse<PagedResult<ResponseComapnyDto>>.SuccessResponse(res,
                "Data fetched Successfuuly!"));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _companyService.GetByIdAsync(id);
            return Ok(ApiResponse<ResponseComapnyDto?>.SuccessResponse(res,
                "Data retrueved Successfully!"));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateCompanyDto dto)
        {
            _logger.LogInformation("Create Company");
            await _companyService.AddAsync(dto);
            _logger.LogInformation("Company Created Successfully!");
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Data Created Successfully!"));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateComapnyDto dto)
        {
            _logger.LogInformation("Update Company with ID:{CompanyId}",id);
            await _companyService.UpdateAsync(id, dto);
            _logger.LogInformation("Company with ID:{CompanyId} Update Successfully!",id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Data Updated Successfully!")); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting Company with ID:{CompanyId} deleted Successfully!", id);
            await _companyService.DeleteAsync(id);
            _logger.LogInformation("Deleted Company with ID:{CompanyId} Successfully!", id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Data Deleted Successfully!"));
        }
    }
}
