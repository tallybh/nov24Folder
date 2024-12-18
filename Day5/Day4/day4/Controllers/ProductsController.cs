using day4.Contracts;
using day4.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace day4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductsRepository productRepository;
    private readonly IRabbitMQ rabbit;
    public ProductsController(IProductsRepository repository, IRabbitMQ rabbit)
    {
        productRepository = repository;
        this.rabbit = rabbit;   
    }
    // GET: api/<ProductsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        //await rabbit.SendProductMessageAsync("Get Called");
        return  Ok(await productRepository.GetAllProducts());
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Product>> Get(int id)
    {
        var p = await productRepository.GetById(id);
        return p == null ? NotFound() : Ok(p);
    }

    // POST api/<ProductsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post([FromBody] Product p)
    {
        bool res = await productRepository.Add(p);
        return res ? Ok() : StatusCode(500);
    }

    // PUT api/<ProductsController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] Product product)
    {
        var res = await productRepository.Update(product);
        return res ? Ok() : NotFound();

    }

    // DELETE api/<ProductsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var res = await productRepository.Delete(id);
        return res ? Ok() : NotFound();
    }
}
