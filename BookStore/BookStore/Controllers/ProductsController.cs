using BookStore.DTO;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IBookService service;

        public ProductsController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await service.GetBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await service.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBook(BookDTORequest book)
        {
            return Ok(await service.AddBook(book));
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutBook(int id, BookDTORequest request)
        {
            await service.UpdateBookAsync(id, request);
            var book = await service.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await service.DeleteBookAsync(id);
            var book = await service.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }
    }
}
