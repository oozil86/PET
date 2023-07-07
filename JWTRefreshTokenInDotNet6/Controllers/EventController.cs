

using PET.Iservices;
using PET.Models;

namespace GraduationProject.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("corsapp")]

public class EventController : ControllerBase
{
    private readonly IEventsService _iservice;
    public EventController(IEventsService iservice)
    {
        _iservice = iservice;
    }
    [HttpPost("AddEvents")]
    public async Task<IActionResult> AddEvents(Events model)
    {
        if (ModelState.IsValid) return Ok(await _iservice.AddEvents(model));
        else return BadRequest();
    }


    [HttpGet("ApproveEvents/{id}")]
    public async Task<IActionResult> ApproveEvents(int id)
    {
        if (ModelState.IsValid && id > 0)
        {
            return Ok(await _iservice.ApproveEvents(id));
        }
        else return BadRequest();
    }
    [HttpGet("DeclineEvents/{id}")]
    public async Task<IActionResult> DeclineEvents(int id)
    {
        if (ModelState.IsValid && id > 0)
        {
            return Ok(await _iservice.DeclineEvents(id));
        }
        else return BadRequest();
    }

    [HttpPost("EditEvents")]
    public async Task<IActionResult> EditEvents(Events model)
    {
        if (ModelState.IsValid) return Ok(await _iservice.EditEvents(model));
        else return BadRequest();
    }


    [HttpGet("DeleteEvents/{id}")]
    public async Task<IActionResult> DeleteEvents(int id)
    {
        if (ModelState.IsValid && id > 0)
        {
            return Ok(await _iservice.DeleteEvents(id));
        }
        else return BadRequest();
    }


    [HttpGet("GetAllEvents")]
    public async Task<IActionResult> GetAllEvents()
    {
        if (ModelState.IsValid) return Ok(await _iservice.GetEvents());
        else return BadRequest();
    }
}
