using AutoMapper;
using EnterpriseERP.Application.DTO.Branch;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Domain.Model;
using EnterpriseERP.Insfrastructure.Implementation;
using Moq;

namespace EnterpriseERP.Infrastructure.Test.Service
{
    public class BranchServiceTest
    {
        private readonly Mock<IGenericRepository<Branch>> _genericRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly BranchService _branchService;

        public BranchServiceTest()
        {
            _genericRepository = new Mock<IGenericRepository<Branch>>();
            _mapper = new Mock<IMapper>();

            _branchService = new BranchService(
                _genericRepository.Object,
                _mapper.Object
            );
        }

        [Fact]
        public async Task GetByIdAsync_shouldreturnId()
        {
            // Arrange
            var branch = new Branch
            {
                Id = 1
            };

            var dto = new ResponseBranchDto
            {
                Id = 1
            };

            _genericRepository
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(branch);

            _mapper
                .Setup(x => x.Map<ResponseBranchDto>(branch))
                .Returns(dto);

            // Act
            var result = await _branchService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturn()
        {
            // Arrange
            var branches = new List<Branch>
    {
        new Branch { Id = 1 },
        new Branch { Id = 2 }
    };

            var dtos = new List<ResponseBranchDto>
    {
        new ResponseBranchDto { Id = 1 },
        new ResponseBranchDto { Id = 2 }
    };

            _genericRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(branches);

            _mapper
                .Setup(x => x.Map<IEnumerable<ResponseBranchDto>>(branches))
                .Returns(dtos);

            // Act
            var result = await _branchService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task AddBranch_shouldAddBranch()
        {
            // Arrange
            var dto = new CreateBranchDto
            {
                Name = "Ireland"
            };

            var branch = new Branch
            {
                Id = 1,
                Name = "Ireland"
            };

            _mapper
                .Setup(x => x.Map<Branch>(dto))
                .Returns(branch);

            _genericRepository
                .Setup(x => x.AddAsync(branch))
                .Returns(Task.CompletedTask);

            // Act
            await _branchService.CreateAsync(dto);

            // Assert
            _genericRepository.Verify(
                x => x.AddAsync(branch),
                Times.Once
            );
        }
        [Fact]
        public async Task UpdateBranch_ShouldUpdateReturn()
        {
            // Arrange
            var dto = new UpdateBranchDto
            {
                Name = "Pakistan"
            };

            var branch = new Branch
            {
                Id = 1,
                Name = "Ireland"
            };

            _genericRepository
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(branch);

            _mapper
                .Setup(x => x.Map(dto, branch))
                .Callback(() => branch.Name = dto.Name);

            _genericRepository
                .Setup(x => x.UpdateAsync(branch))
                .ReturnsAsync(true);

            // Act
            var result = await _branchService.UpdateAsync(1, dto);

            // Assert
            Assert.True(result);
            Assert.Equal("Pakistan", branch.Name);

            _genericRepository.Verify(
                x => x.GetByIdAsync(1),
                Times.Once
            );

            _mapper.Verify(
                x => x.Map(dto, branch),
                Times.Once
            );

            _genericRepository.Verify(
                x => x.UpdateAsync(branch),
                Times.Once
            );
        }
        [Fact]
        public async Task DeleteBranch_ShouldDeleteBranch()
        {
            // Arrange
            var branch = new Branch
            {
                Id = 1,
                Name = "Ireland"
            };

            _genericRepository
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(branch);

            _genericRepository
                .Setup(x => x.DeleteAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await _branchService.DeleteAsync(1);

            // Assert
            Assert.True(result);

            _genericRepository.Verify(
                x => x.GetByIdAsync(1),
                Times.Once
            );

            _genericRepository.Verify(
                x => x.DeleteAsync(1),
                Times.Once
            );
        }
    }
}