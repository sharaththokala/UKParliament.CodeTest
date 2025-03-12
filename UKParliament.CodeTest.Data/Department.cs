namespace UKParliament.CodeTest.Data;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<Person> People { get; set; }
}
