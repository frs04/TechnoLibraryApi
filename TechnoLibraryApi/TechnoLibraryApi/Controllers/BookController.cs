using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnoLibraryApi.Models;

namespace TechnoLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //constructor
        private readonly TechnoLibDbContext lib;

        public BookController(TechnoLibDbContext library)
        {
            lib = library;
        }
        //end of constructor

        [HttpGet("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            return lib.Books;
        }
    }
}
