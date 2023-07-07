using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PET.Iservices;
using PET.Models;

namespace PET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishProductController : ControllerBase
    {

        private readonly IWishProductService _iservice;
        public WishProductController(IWishProductService service) => _iservice = service;

        [HttpPost("AddWishProduct")]
        public async Task<IActionResult> AddWishProduct(WishProduct model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.AddWishProduct(model));
            else return BadRequest();
        }


        [HttpGet("GetAllWishProduct")]
        public async Task<IActionResult> GetAllWishProduct()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllWishProduct());
            else return BadRequest();
        }

        [HttpGet("DeleteWishProduct/{id}")]
        public async Task<IActionResult> DeleteWishProduct(int id)
        {
            if (ModelState.IsValid) return Ok(await _iservice.DeleteWishProduct(id));
            else return BadRequest();
        }
    }
}
