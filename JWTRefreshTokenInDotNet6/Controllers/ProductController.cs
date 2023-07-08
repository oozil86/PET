using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PET.Iservices;
using PET.Models;
using PET.Services;
using System.Net.Http.Headers;

namespace PET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iservice;
        public ProductController(IProductService service) => _iservice = service;

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.AddProduct(model));
            else return BadRequest();
        }


        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct(Product model)
        {
            if (ModelState.IsValid) return Ok(await _iservice.EditProduct(model));
            else return BadRequest();
        }


        [HttpGet("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (ModelState.IsValid && id > 0)
            {
                return Ok(await _iservice.DeleteProduct(id));
            }
            else return BadRequest();
        }


        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllProduct());
            else return BadRequest();
        }

        [HttpGet("GetAllProductBySubCate/{SubCategoryId}")]
        public async Task<IActionResult> GetAllProductBySubCate(int SubCategoryId)
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllProductBySubCate(SubCategoryId));
            else return BadRequest();
        }

        [HttpPost("Upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileInfo = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileName = Request.Form["Product.Id"].ToString() + Path.GetExtension(fileInfo);
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine("Images", fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    await _iservice.SaveProductPath(dbPath, Convert.ToInt32(Request.Form["Product.Id"].ToString()));
                    return Ok(new { fullPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllCategory());
            else return BadRequest();
        }

        [HttpGet("GetAllSubCate")]
        public async Task<IActionResult> GetAllSubCate()
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllSubCate());
            else return BadRequest();
        }

        //
        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage()
        {
           // string path = $"{Directory.GetCurrentDirectory()}{@"\Resources\Images"}";
           string path="mahmoud";
            return Ok(path);
        }


        [HttpGet("GetAllProductById/{ProductId}")]
        public async Task<IActionResult> GetAllProductById(int ProductId)
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllProductById(ProductId));
            else return BadRequest();
        }


        [HttpGet("GetAllSubCategory/{CategoryId}")]
        public async Task<IActionResult> GetAllSubCategory(int CategoryId)
        {
            if (ModelState.IsValid) return Ok(await _iservice.GetAllSubCategory(CategoryId));
            else return BadRequest();
        }
    }
}
