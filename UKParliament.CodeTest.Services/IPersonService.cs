using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    public Task<ICollection<PersonListItemModel>> GetPeopleAsync();

    public Task<PersonModel> GetPersonByIdAsync(int Id);
}