using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PET.Iservices;
using PET.Models;

namespace PET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _iservice;
        public ClinicController(IClinicService service) => _iservice = service;

        [HttpPost("AddClinic")]
        public async Task<IActionResult> AddClinic(Clinic model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.AddClinic(model));
            else return BadRequest();
        }


        [HttpPost("EditClinic")]
        public async Task<IActionResult> EditClinic(Clinic model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.EditClinic(model));
            else return BadRequest();
        }


        [HttpGet("DeleteClinic/{id}")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            if (ModelState.IsValid && id > 0)
            {
                return Ok(await _iservice.DeleteClinic(id));
            }
            else return BadRequest();
        }


        [HttpGet("GetAllClinic")]
        public async Task<IActionResult> GetAllClinic()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllClinic());
            else return BadRequest();
        }


    }
}
