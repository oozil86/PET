using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PET.Iservices;
using PET.Models;

namespace PET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroomingController : ControllerBase
    {
        private readonly IGroomingService _iservice;
        public GroomingController(IGroomingService service) => _iservice = service;

        [HttpPost("AddGrooming")]
        public async Task<IActionResult> AddGrooming(Grooming model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.AddGrooming(model));
            else return BadRequest();
        }


        [HttpPost("EditGrooming")]
        public async Task<IActionResult> EditGrooming(Grooming model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.EditGrooming(model));
            else return BadRequest();
        }

        [HttpPost("BookGrooming")]
        public async Task<IActionResult> BookGrooming(Grooming model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.BookGrooming(model));
            else return BadRequest();
        }
        

        [HttpGet("GroomingById/{Id}")]
        public async Task<IActionResult> GroomingById(int Id)
        {
            if (ModelState.IsValid) return Ok(await _iservice.GroomingById(Id));
            else return BadRequest();
        }

        [HttpGet("DeleteGrooming/{id}")]
        public async Task<IActionResult> DeleteGrooming(int id)
        {
            if (ModelState.IsValid && id > 0)
            {
                return Ok(await _iservice.DeleteGrooming(id));
            }
            else return BadRequest();
        }


        [HttpGet("GetAllGrooming")]
        public async Task<IActionResult> GetAllGrooming()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllGrooming());
            else return BadRequest();
        }
    }
}
