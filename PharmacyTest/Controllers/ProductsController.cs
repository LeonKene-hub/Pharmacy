using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyTest.Domains;
using PharmacyTest.Interfaces;
using PharmacyTest.Repositories;

namespace PharmacyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _productsRepository;

        public ProductsController()
        {
            _productsRepository = new ProductsRepository();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                List<Products> lista = new List<Products>();
                lista = _productsRepository.GetAll();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Products finded = _productsRepository.GetById(id);
                return Ok(finded);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Products newProduct)
        {
            try
            {
                _productsRepository.Post(newProduct);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, Products newProduct)
        {
            try
            {
                _productsRepository.Put(id, newProduct);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
