using DbEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            if (model == null) {


                //var book = new 
                //appContext.Books.Add(model);
                //await appContext.SaveChangesAsync();
                // return Ok(model);
                return BadRequest();
            }

            _appDbContext.Books.Add(model);
            await _appDbContext.SaveChangesAsync();

            return Ok(model);
        }
    }
}
