using UKParliament.CodeTest.Data.Repositories;
using UKParliament.CodeTest.Services.Exceptions;
using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{
    private readonly IPeopleRepository _peopleRepository;

    public PersonService(IPeopleRepository peopleRepository)
    {
        _peopleRepository = peopleRepository;
    }

    public async Task<ICollection<PersonListItemModel>> GetPeopleAsync()
    {
        var people = await _peopleRepository.GetPeopleAsync();

        return people.Select(p => new PersonListItemModel (p.Id, p.FirstName, p.LastName, p.DateOfBirth, p.Department.Name, p.UpdatedOn )).ToList();
    }

    public async Task<PersonModel> GetPersonByIdAsync(int Id)
    {
        var person = await _peopleRepository.GetPersonByIdAsync(Id);

        if (person == null)
            throw new PersonNotFoundException();

        return new PersonModel
        {
            Id = person.Id,
            DepartmentId = person.DepartmentId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
        };
    }
}