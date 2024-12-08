using Microsoft.AspNetCore.Mvc;
using MyDay2.Contracts;
using MyDay2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyDay2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;


        public BlogsController(IBlogRepository rep) {
            blogRepository = rep;
        }
        // GET: api/<BlogsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Blog>>> Get()
        {
            return Ok(await blogRepository.GetAllBlogs());
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            var p = await blogRepository.GetById(id);
            return p == null ? NotFound() : Ok(p);
        }
        

        // POST api/<BlogsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] Blog blog)
        {
            await blogRepository.Add(blog);
            return Ok();
        }

        // PUT api/<BlogsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromBody] Blog blog)
        {
            var res = await blogRepository.Update(blog);
            return res ? Ok() : NotFound();
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await blogRepository.Delete(id);
            return res ? Ok() : NotFound();
        }



    }
}
