using Moq;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Exceptions;
using Xunit;

namespace UKParliament.CodeTest.Tests.Services;

public class PersonServiceTests
{
    [Fact]
    public async Task GetPersonByIdAsync_ThrowsNotFoundException()
    {
        //Arrange
        IPersonService personService;
        var repository = new Mock<IPeopleRepository>();

        repository.Setup(x => x.GetPersonByIdAsync(It.IsAny<int>())).ReturnsAsync((Person?)null);


        personService = new PersonService(repository.Object);

        ////Act
        ////Assert
        _ = await Assert.ThrowsAsync<PersonNotFoundException>(async () => await personService.GetPersonByIdAsync(1));
        repository.Verify(v => v.GetPersonByIdAsync(1), Times.Once);
    }
}
