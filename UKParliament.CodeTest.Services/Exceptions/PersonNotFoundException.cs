using System.Net;

namespace UKParliament.CodeTest.Services.Exceptions;

public class PersonNotFoundException : Exception
{
    public PersonNotFoundException(int id) :
        base($"person with id {id} not found")
    {
    }
}
