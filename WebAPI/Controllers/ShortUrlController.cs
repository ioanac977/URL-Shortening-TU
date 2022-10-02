using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly ShortUrlService _shortUrlService;

        public ShortUrlController(ShortUrlService shortUrlService) =>
            _shortUrlService = shortUrlService;

        // GET: api/<ShortUrlController>
        [HttpGet]
        public async Task<List<ShortUrl>> Get() =>
             await _shortUrlService.GetAsync();


        // GET api/<ShortUrlController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ShortUrl>> Get(string id)
        {
            var book = await _shortUrlService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }


        // POST api/<ShortUrlController>
        [HttpPost]
        public async Task<IActionResult> Post(ShortUrl newShortUrl)
        {
            await _shortUrlService.CreateAsync(newShortUrl);

            return CreatedAtAction(nameof(Get), new { Hash = newShortUrl.Hash }, newShortUrl);
        }


        // DELETE api/<ShortUrlController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _shortUrlService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _shortUrlService.RemoveAsync(id);

            return NoContent();
        }
    }
}
