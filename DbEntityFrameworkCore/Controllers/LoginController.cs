using DbEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbEntityFrameworkCore.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private string message;

        public LoginController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }


        [HttpPost("User")]
        public async Task<IActionResult> AddNewBook([FromBody] Login model)
        {

            if (string.IsNullOrEmpty(model.FirstName) && string.IsNullOrEmpty(model.Email))
            {


                //var book = new 
                //appContext.Books.Add(model);
                //await appContext.SaveChangesAsync();
                // return Ok(model);
                return BadRequest("Smething went wrong !!");
            }

            _appDbContext.UserLogin.Add(model);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Account Created Successfully !!",
                // Data = model
            });

        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var user = _appDbContext.UserLogin.Where(x=>x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] Login request)
        {
            if(string.IsNullOrEmpty(request.Email)|| string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email and password are required");

            }
            var user = await _appDbContext.UserLogin.FirstOrDefaultAsync(u=>u.Email== request.Email&& u.Password == request.Password);
            if (user== null)
                
            {
                return Unauthorized("Invailid email or password");
            }
            user.Password = "";
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {

            var user = _appDbContext.UserLogin.FirstOrDefault(x => x.Id == id);
              
                 
            if (user == null)
            {
                return NotFound(message =$"User With ID{id} not found");
            }
            _appDbContext.UserLogin.Remove((Login)user);
            await _appDbContext.SaveChangesAsync();
            return Ok(message = $"User with ID {id} has been deleted successfully.");

        }

        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<Login>>> GetAllUser()
        {
            var allUsers = await _appDbContext.UserLogin.ToListAsync();
            return Ok(allUsers);
        }

    }
}
