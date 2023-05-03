using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Data.DTOs.Library;
using WebApplication8.Data.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarysController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public LibrarysController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet] IActionResult GetAllLibrary()
        {
            var allLibrary = _appDbContext.Library.ToList();
            return Ok(allLibrary);
        }

        [HttpGet("GetLibraryById/{id}")]
        public IActionResult GetLibraryById(int id)
        {
            var Library = _appDbContext.Library.FirstOrDefault(x => x.Id == id);
            return Ok($"Library me id = {id} u kthye me sukses!");
        }

        [HttpPost("AddLibrary")]
        public IActionResult AddLibrary([FromBody] PostLibraryDTO payload)
        {
            Library newLibrary = new Library()
            {
                Name = payload.Name,
                Id = payload.Id,
                title = payload.Title,
                description = payload.Description,
                

            };

            _appDbContext.Library.Add(newLibrary);
            _appDbContext.SaveChanges();

            return Ok("Library u krijua me sukses!");
        }

        [HttpPut("UpdateLibrary")]
        public IActionResult UpdateLibraary([FromBody] PutLibraryDTO payload, int id)
        {
            var library = _appDbContext.Library.FirstOrDefault(x => x.Id == id);
            if (library == null)
                return NotFound();

            library.Name = payload.Name;    
            library.Id = payload.Id;
            library.title = payload.Title;
            library.description = payload.Description;



            _appDbContext.Library.Update(library);
            _appDbContext.SaveChanges();

            return Ok("Library u modifikua me sukses!");
        }

        [HttpDelete("DeleteLibrary/{id}")]
        public IActionResult DeleteLibrary(int id)
        {
            var library = _appDbContext.Library.FirstOrDefault(x => x.Id == id);
            if (library == null)
                return NotFound();

            _appDbContext.Library.RemoveRange();
            _appDbContext.SaveChanges();

            return Ok($"Library me id = {id} u fshi me sukses!");
        }
    }
}