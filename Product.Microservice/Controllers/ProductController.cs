using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Data;
using Product.Microservice.Services;
using System;
using System.Threading.Tasks;

namespace Customer.Microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAllAsync());

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _productService.GetById(id);
                if (customer == null)
                    return NotFound("cant found");

                return Ok(customer);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);

            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product.Microservice.Models.Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdProduct = await _productService.CreateAsync(product);
                return Ok(createdProduct.Name + " Has Been Created!");

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);

            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product.Microservice.Models.Product product)
        {
            try
            {
                if (product == null)
                    return NotFound("cant found");

                await _productService.UpdateAsync(id, product);
                return Ok(product.Name + " Updated!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

    }
}
