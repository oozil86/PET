using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PET.Iservices;
using PET.Models;

namespace PET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesProductController : ControllerBase
    {



        private readonly ISalesProductService _iservice;
        public SalesProductController(ISalesProductService service) => _iservice = service;

        [HttpPost("AddSalesProduct")]
        public async Task<IActionResult> AddSalesProduct(SalesProduct model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.AddSalesProduct(model));
            else return BadRequest();
        }


        [HttpGet("GetAllSalesProduct")]
        public async Task<IActionResult> GetAllSalesProduct()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllSalesProduct());
            else return BadRequest();
        }


        [HttpGet("DeleteSalesProduct/{id}")]
        public async Task<IActionResult> DeleteSalesProduct(int id)
        {
            if (ModelState.IsValid) return Ok(await _iservice.DeleteSalesProduct(id));
            else return BadRequest();
        }
    }
}
