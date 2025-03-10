using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.Services.Models;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PersonListItemModel>>> Get()
    {
        return Ok(await _personService.GetPeopleAsync());
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<PersonModel>> GetById(int id)
    {
        return Ok(await _personService.GetPersonByIdAsync(id));
    }
}