namespace UKParliament.CodeTest.Data.Repositories;

public interface IPeopleRepository
{
    Task<IEnumerable<Person>> GetPeopleAsync();
    Task<Person?> GetPersonByIdAsync(int personId);
    Task InsertPersonAsync(Person person);
    Task UpdatePersonAsync(Person person);
}
