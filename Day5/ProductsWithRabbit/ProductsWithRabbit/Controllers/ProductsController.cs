using Microsoft.AspNetCore.Mvc;
using ProductsWithRabbit.Contracts;
using ProductsWithRabbit.Models;
using ProductsWithRabbit.Rabbit;
using ProductsWithRabbit.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsWithRabbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRabbitMQProducer _rabitMQProducer;
        private ILogger<ProductsController> _logger { get; }

        public ProductsController(IProductService _productService,
                IRabbitMQProducer rabitMQProducer,
                ILogger<ProductsController> logger)
        {
            productService = _productService;
            _rabitMQProducer = rabitMQProducer;
            _logger = logger;    
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogError("Get All Products is Called");
            var products = await productService.GetAllProducts();
            return Ok(products);
            
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var product = await productService.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            Product result = await productService.AddNewProduct(product);
            if(result != null)
            {
                _rabitMQProducer.SendProductMessage(result);
                return Ok(result);
            }

            return NotFound();

        }

        // PUT api/<ProductsController>/5
        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] Product product)
        //{


        //}

        // DELETE api/<ProductsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
