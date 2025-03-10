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
    public async Task<ActionResult<PersonViewModel>> GetById(int id)
    {
        return Ok(await _personService.GetPersonByIdAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PersonAddModel person)
    {
        await _personService.AddPersonAsync(person);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] PersonViewModel person, int id)
    {
        await _personService.UpdatePersonAsync(id, person);
        return Ok();
    }

}