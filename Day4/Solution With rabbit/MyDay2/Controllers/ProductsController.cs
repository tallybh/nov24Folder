using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyDay2.Contracts;
using MyDay2.Models;
using MyDay2.RabbitMQ;
using MyDay2.Services;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyDay2.Controllers;


[Route("api/[controller]")]
[ApiController]

public class ProductsController : ControllerBase
{
    private readonly IProductMock productMock;
    private readonly AppDbContext appDbContext;
    private readonly IRabbitMQ _rabbitMQ;
    public ProductsController(IProductMock mock, AppDbContext context, IRabbitMQ rabbitMQ)
    {
        productMock = mock;
        appDbContext = context;
        _rabbitMQ = rabbitMQ;
    }
    // GET: api/<ProductsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
 
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        
        return Ok(appDbContext.Products);
        //var products = await productMock.GetAllProducts();
        //return Ok(products);
    }

    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Product>> Get(int id)
    {
        var p = await productMock.GetById(id);
        return p==null ? NotFound(): Ok(p);  
    }

    // POST api/<ProductsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post([FromBody] Product p)
    {
        await _rabbitMQ.SendProductMessageAsync(p);
        bool res = await productMock.Add(p);
        return res? Ok(): StatusCode(500);
    }

    // PUT api/<ProductsController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] Product product)
    {
        var res = await productMock.Update(product);
        return res ? Ok() : NotFound();

    }

    // DELETE api/<ProductsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var res = await productMock.Delete(id);
        return res ? Ok() : NotFound();
    }
}
