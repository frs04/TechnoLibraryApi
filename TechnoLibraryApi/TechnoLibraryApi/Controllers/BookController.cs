using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;
using TechnoLibraryApi.Custom_Models;
using TechnoLibraryApi.Models;

namespace TechnoLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //constructor
        private readonly TechnoLibContext lib;
        private readonly IWebHostEnvironment Environment;
        private readonly IConfiguration Configuration;


        public BookController(TechnoLibContext library,IWebHostEnvironment _environment, IConfiguration _configuration)
        {
            lib = library;
            Environment = _environment;
            Configuration = _configuration;
        }
        //end of constructor
        [HttpGet("GetBooks")]
        public JsonResult GetBooks()
        {
            string query = @"select b.BookId,b.BookName,c.CategoryName,b.PublisherName,a.AuthorName,b.Pages,b.PicturePath,b.Description,b.ReleaseDate,b.ISBN
 from Book as b left join Category as c on c.CategoryId = b.CategoryId left join Author as a on a.AuthorId = b.AuthorId ";
            DataTable table = new();
            string sqlDataSource = Configuration.GetConnectionString("con");
            SqlDataReader myReader;
            using (SqlConnection myCon = new(sqlDataSource))
            {
                myCon.Open();
                using SqlCommand myCommand = new(query, myCon);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();

            }
            return new JsonResult(table);
        }
        //[HttpGet("GetBooks")]
        //public IEnumerable<Book> GetBooks()
        //{
        //    return lib.Books;
        //}

        //[HttpGet("GetBook/{id}")]
        //public IActionResult GetBook(int id)
        //{

        //    var w = lib.Books.Where(a => a.BookId == id).FirstOrDefault();
        //    if (w == null)
        //    {
        //        return NotFound("Book Not Found");
        //    }
        //    else
        //    {
        //        return Ok(w);
        //    }
        //}


        [HttpPost("UploadImage")]
        public IActionResult UploadImage([FromForm] ImageUploaderClass imageForm)
        {
            try
            {
                if (imageForm.FormFile != null)
                {

                    string path = Path.Combine(this.Environment.ContentRootPath, "Images");
                    //Create a Folder.
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //Save the uploaded Excel file.
                    string fileName = Path.GetFileName(imageForm.FormFile.FileName);
                    string filePath = Path.Combine(path, fileName);
                    using (FileStream stream = new(filePath, FileMode.Create))
                    {
                        imageForm.FormFile.CopyTo(stream);
                    }
                    string[] s = fileName.Split('.');
                    return Ok(filePath);
                }
                else return NotFound("Can't insert null value");
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
