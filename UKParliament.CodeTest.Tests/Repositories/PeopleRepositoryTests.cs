using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Repositories;
using Xunit;

namespace UKParliament.CodeTest.Tests.Repositories;

public class PeopleRepositoryTests
{
    private IPeopleRepository peopleRepository;
    private PersonManagerContext personManagerContext;

    public PeopleRepositoryTests()
    {
        var dbOptions = new DbContextOptionsBuilder<PersonManagerContext>()
         .UseInMemoryDatabase(databaseName: "person_db")
         .Options;

        personManagerContext = new PersonManagerContext(dbOptions);

        peopleRepository = new PeopleRepository(personManagerContext);
    }

    [Fact]
    public async Task InsertPersonAsync_HasAuditDatesPopulated()
    {
        //Arrange

        personManagerContext.Departments.Add(new Department { Id = 1, Name = "test" });
        await personManagerContext.SaveChangesAsync();

        var personToAdd = new Person { FirstName = "sharath", LastName = "thokala", DepartmentId = 1, DateOfBirth = new DateOnly(1986, 02, 12) };

        //Act
        await peopleRepository.InsertPersonAsync(personToAdd);

        //Assert
        var person = await personManagerContext.People.FirstAsync();

        Assert.True(person.CreatedOn.HasValue);
        Assert.True(person.UpdatedOn.HasValue);
    }

    public void Dispose()
    {
        personManagerContext.Database.EnsureDeleted();
        personManagerContext.Dispose();
    }
}
