using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    public Task<ICollection<PersonListItemModel>> GetPeopleAsync();

    public Task<PersonViewModel> GetPersonByIdAsync(int Id);

    public Task AddPersonAsync(PersonAddModel person);

    public Task UpdatePersonAsync(int Id, PersonViewModel person);
}