using BookStore.Service.DTOs.BookDTOs;
using BookStore.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("Book-Package")]
    public class BookController : ControllerBase
    {
        public IBookService bookService { get; set; }

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BookForCreationDTO book) =>
            Ok(await bookService.CreateAsync(book));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync() 
            => Ok(await bookService.GetAllAsync());

    }
}
