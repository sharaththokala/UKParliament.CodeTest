using Moq;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Services;
using Xunit;

namespace UKParliament.CodeTest.Tests.Services;

public class DepartmentServiceTests
{
    [Fact]
    public async Task GetDepartments_MapsToModel()
    {
        //Arrange
        IDepartmentService departmentService;
        var repository = new Mock<IDepartmentRepository>();

        repository.Setup(x => x.GetDepartmentsAsync()).ReturnsAsync(
            new[]
            { new Department {Id = 1, Name = "test1" },
              new Department {Id = 2, Name ="test2"}
            });

        departmentService = new DepartmentService(repository.Object);

        //Act
        var result = (await departmentService.GetDepartments()).ToList();

        //Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("test1", result[0].Name);
        Assert.Equal("test2", result[1].Name);
    }
}
