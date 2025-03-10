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

        return people.Select(p => new PersonListItemModel(p.Id, p.FirstName, p.LastName, p.DateOfBirth, p.Department.Name, p.UpdatedOn)).ToList();
    }

    public async Task<PersonViewModel> GetPersonByIdAsync(int Id)
    {
        var person = await _peopleRepository.GetPersonByIdAsync(Id);

        if (person == null)
            throw new PersonNotFoundException(Id);

        return new PersonViewModel
        {
            Id = person.Id,
            DepartmentId = person.DepartmentId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
        };
    }
    public async Task AddPersonAsync(PersonAddModel person)
    {
        await _peopleRepository.InsertPersonAsync(new Data.Person
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            DepartmentId = person.DepartmentId,
        });
    }

    public async Task UpdatePersonAsync(int Id, PersonViewModel person)
    {
        var personToUpdate = await _peopleRepository.GetPersonByIdAsync(Id);

        if (personToUpdate == null)
            throw new PersonNotFoundException(Id);

        personToUpdate.FirstName = person.FirstName;
        personToUpdate.LastName = person.LastName;
        personToUpdate.DepartmentId = person.DepartmentId;
        personToUpdate.DateOfBirth = person.DateOfBirth;
       
        await _peopleRepository.UpdatePersonAsync(personToUpdate);
    }
}