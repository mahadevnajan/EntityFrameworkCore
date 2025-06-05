using DbEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbEntityFrameworkCore.Controllers
{
    [Route("api/currencies")]
    [ApiController]


    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            // var result = this.appDbContext.currencies.ToList();
            //var result = from currencies in _appDbContext.currencies
            //           select currencies;

            //asyn wait 
            var result = await _appDbContext.Currencies.ToListAsync();
            //           select currencies;
            return Ok(result.ToList());

        }
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int id)
        {

            //asyn wait 
            var result = await _appDbContext.Currencies.FindAsync(id);
            //           select currencies;
            return Ok(result);

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyName([FromRoute] string name, [FromQuery] string ? description)
        {
            var result = await _appDbContext.Currencies.FirstOrDefaultAsync(x => 
            x.Title == name
            &&(string.IsNullOrEmpty(description)|| x.Description == description)
            );
            
            if (result == null)
            {
                return BadRequest("Data Not Found");
            }
            return Ok( result);
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll([FromBody] List<int> ides)
        {

            // var id = new List<int> { 1,4,3};
            var result = await _appDbContext.Currencies.Where(x => ides.Contains(x.Id))
                .Select(x => new Currency()
                {
                    Id = x.Id, 
                    Title = x.Title
                }).ToListAsync();
               
            if (result == null)
            {
                return BadRequest("Data Not Found");  
            }
            return Ok(result);
        }

        //Apply Filter 
    }
} 
