using AutoMapper;
using EnterpriseERP.Application.DTO.Branch;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Domain.Model;
using EnterpriseERP.Insfrastructure.Implementation;
using Moq;

namespace EnterpriseERP.Infrastructure.Tests.Services;

public class BranchServiceTests
{
    private readonly Mock<IGenericRepository<Branch>> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly BranchService _service;

    public BranchServiceTests()
    {
        _repositoryMock = new Mock<IGenericRepository<Branch>>();
        _mapperMock = new Mock<IMapper>();

        _service = new BranchService(
            _repositoryMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrow_WhenBranchDoesNotExist()
    {
        // Arrange
        var branchId = 1;

        _repositoryMock
            .Setup(x => x.GetByIdAsync(branchId))
            .ReturnsAsync((Branch?)null);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(
            () => _service.GetByIdAsync(branchId)
        );
    }
}
