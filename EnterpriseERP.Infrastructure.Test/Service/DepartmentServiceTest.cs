using AutoMapper;
using EnterpriseERP.Application.DTO.Department;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Domain.Model;
using EnterpriseERP.Insfrastructure.Implementation;
using Moq;
using NuGet.Frameworks;

namespace EnterpriseERP.Infrastructure.Test.Service
{
    public class DepartmentServiceTest
    {
            private readonly Mock<IGenericRepository<Department>> _departmentRepo;
            private readonly Mock<IMapper> _mapper;
            private readonly DepartmentService _departmentService;

            public DepartmentServiceTest()
            {
                _departmentRepo = new Mock<IGenericRepository<Department>>();
                _mapper = new Mock<IMapper>();

                _departmentService = new
                    DepartmentService(
                        _departmentRepo.Object,
                        _mapper.Object
                    );
            }

             [Fact]
             public async Task GetByIdAsync_ShouldReturnId()
             {
            var department = new Department
            {
                Id = 1
            };

            var dto = new ResponseDepartmentDto
            {
                Id = 1
            };
            _departmentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(department);
            _mapper.Setup(x => x.Map<ResponseDepartmentDto>(department)).Returns(dto);

            var depart = await _departmentService.GetByIdAsync(1);

            Assert.NotNull(depart);
            Assert.Equal(1, depart.Id);
          }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            var department = new List<Department>
            {
               new Department {Id = 1},
               new Department {Id = 2}
            };
            var dto = new List<ResponseDepartmentDto>
            {
                new ResponseDepartmentDto { Id = 1},
                new ResponseDepartmentDto {Id =2}
            };
            _departmentRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(department);
            _mapper.Setup(x => x.Map<IEnumerable<ResponseDepartmentDto>>(department)).Returns(dto);
            var res = await _departmentService.GetAllAsync();
            Assert.NotNull(res);
            Assert.Equal(2, res.Count());
        }
        [Fact]
        public async Task AddAsync_ShouldReturnAdd()
        {
            var dto = new CreateDepartmentDto
            {
                Name = "Karachi"
            };
            var department = new Department
            {
                Id = 1,
                Name = "Sialkot"
            };
            _departmentRepo.Setup(x => x.AddAsync(department)).Returns(Task.CompletedTask);
            await _departmentService.AddAsync(dto);
        }
       }
    }