using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    public Task<ICollection<PersonListItemModel>> GetPeopleAsync();

    public Task<PersonModel> GetPersonByIdAsync(int Id);

    public Task AddPersonAsync(PersonModel person);

    public Task UpdatePersonAsync(int Id, PersonViewModel person);
}