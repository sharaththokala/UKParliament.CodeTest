using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private readonly PersonManagerContext _context;

    public PeopleRepository(PersonManagerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetPeopleAsync() => await _context.People.Include(p => p.Department).ToListAsync();

    public async Task<Person?> GetPersonByIdAsync(int personId) => await _context.People.FirstOrDefaultAsync(p => p.Id == personId);

    public async Task InsertPersonAsync(Person person)
    {
        person.CreatedOn = DateTime.UtcNow;

        person.UpdatedOn = DateTime.UtcNow;

        _context.People.Add(person);

       await _context.SaveChangesAsync();
    }

    public async Task UpdatePersonAsync(Person person)
    {
        person.UpdatedOn = DateTime.UtcNow;

        _context.Entry(person).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
