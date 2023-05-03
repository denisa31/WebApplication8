using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Data.DTOs.Book;
using WebApplication8.Data.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public BooksController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet("GetAllBook")]
        public IActionResult GetAllBook()
        {
            var allBook = _appDbContext.Book.ToList();

            return Ok(allBook);
        }

        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _appDbContext.Book.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] PostBookDTO payload)
        {
            Book newBook = new Book()
            {
                Name = payload.Name,
                Id = payload.Id,
                title = payload.title,
                description = payload.description,
                author = payload.author,
            };

            _appDbContext.Book.Add(newBook);
            _appDbContext.SaveChanges();

            return Ok("Book u krijua me sukses!");
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook([FromBody] PutBookDTO payload, int id)
        {
            var Book = _appDbContext.Book.FirstOrDefault(x => x.Id == id);

            if (Book == null)
                return NotFound();

            Book.Name = payload.Name;
            Book.id = payload.id;
            Book.title = payload.title;
            Book.description = payload.description;
            Book.author = payload.author;

            _appDbContext.Book.Update(Book);
            _appDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _appDbContext.Book.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            _appDbContext.Book.Remove(book);
            _appDbContext.SaveChanges();

            return Ok($"Book me id = {id} u fshi me sukses!");
        }
    }
}
