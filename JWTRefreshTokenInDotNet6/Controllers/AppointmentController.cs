

namespace Alzheimer.Controllers;

[Route("api/[controller]")]
[ApiController]
////[Authorize(Roles = "User")]
//[EnableCors("corsapp")]

public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _iservice;
    public AppointmentController(IAppointmentService service) => _iservice = service;

    [HttpPost("AddAppointment")]
    public async Task<IActionResult> AddAppointment(Appointment model)
    {
        if (ModelState.IsValid) return Ok(await _iservice.AddAppointment(model));
        else return BadRequest();
    }
           

    [HttpPost("UpdateAppointment")]
    public async Task<IActionResult> UpdateAppointment(Appointment model)
    {
        if (ModelState.IsValid) return Ok(await _iservice.UpdateAppointment(model));
        else return BadRequest();
    }
        


    [HttpPost("ChangeAppointment")]
    public async Task<IActionResult> ChangeAppointment(Appointment model)
    {
        if (ModelState.IsValid)
        {
             model.Status =200;
            return Ok(await _iservice.ChangeAppointment(model));
        }
        else
        {
            model.Status = 400;
            return BadRequest();
        }
    }

    [HttpPost("BookAppointment")]
    public async Task<IActionResult> BookAppointment(Appointment model)
    {
        if (ModelState.IsValid)
        {
            model.Status = 200;
            return Ok(await _iservice.BookAppointment(model));
        }
        else
        {
            model.Status = 400;
            return BadRequest();
        }
    }

    [HttpGet("DeleteAppointment/{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        if (ModelState.IsValid && id > 0)
        {
            return Ok(await _iservice.DeleteAppointment(id));
        }
        else return BadRequest();
    }


    [HttpGet("ApproveAppointment/{id}")]
    public async Task<IActionResult> ApproveAppointment(int id)
    {
        if (ModelState.IsValid && id > 0)
        {
            return Ok(await _iservice.ApproveAppointment(id));
        }
        else return BadRequest();
    }
    [HttpGet("DeclineAppointment/{id}")]
    public async Task<IActionResult> DeclineAppointment(int id)
    {
        if (ModelState.IsValid && id > 0)
        {
            return Ok(await _iservice.DeclineAppointment(id));
        }
        else return BadRequest();
    }

    [HttpGet("GetListAppointment")]
    public async Task<IActionResult> GetListAppointment()
    {
        //string origin= Request.Headers["origin"];
        if (ModelState.IsValid) return Ok(await _iservice.GetAppointment());
        else return BadRequest();
    }

    [HttpGet("GetDoctorById/{appointmentId}")]
    public async Task<IActionResult> GetDoctorById(int appointmentId)
    {
        if (ModelState.IsValid) return Ok(await _iservice.GetDoctorById(appointmentId));
        else return BadRequest();
    }
    

}
