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
            List<Products> lista = new List<Products>();
            lista = _productsRepository.GetAll();
            return Ok(lista);
        }
    }
}
