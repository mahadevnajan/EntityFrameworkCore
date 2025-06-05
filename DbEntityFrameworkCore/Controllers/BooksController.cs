using DbEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DbEntityFrameworkCore.Controllers
{
    [Route("api/Book")]
    [ApiController]

    
    public class BooksController : ControllerBase

    {
        private readonly AppDbContext _appDbContext;

        public BooksController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddNewBook([FromBody]Book model)
        {

            if (string.IsNullOrEmpty(model.Title)) {


                //var book = new 
                //appContext.Books.Add(model);
                //await appContext.SaveChangesAsync();
                // return Ok(model);
                return BadRequest("Title Should not be empty");
            }

            _appDbContext.Books.Add(model);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Book Saved Successfully",
               // Data = model
            });

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBook()
        {

          var book = await _appDbContext.Books.ToListAsync();

            return Ok(book);
        }

        //if you want insert bulk data into book , so need to use AddRange method

        [HttpPost("AddBulkBook")]
        public async Task<IActionResult> AddBookData([FromBody] List<Book> model)
        {
            if (model == null || model.Count == 0)
            {
                return BadRequest("Failed to add book");
            }
            else
            {
                var bukBook = this._appDbContext.Books.AddRangeAsync(model);
                await _appDbContext.SaveChangesAsync();

                return Ok( new
                {
                    message = "Successfully Add Books",
                    Data = bukBook
                });
            }
            }
        }
}
