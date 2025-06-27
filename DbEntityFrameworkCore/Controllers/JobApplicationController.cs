using DbEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbEntityFrameworkCore.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private string message;

        public JobApplicationController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpPost("ApplicationForm")]
        public async Task<IActionResult> ApplicationForm([FromBody] JobApplication model)
        {

            if (string.IsNullOrEmpty(model.FirstName) && string.IsNullOrEmpty(model.Email))
            {


                //var book = new 
                //appContext.Books.Add(model);
                //await appContext.SaveChangesAsync();
                // return Ok(model);
                return BadRequest("Smething went wrong !!");
            }

            _appDbContext.JobApply.Add(model);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Application Submitted  Successfully !!",
                // Data = model
            });

        }
        [HttpGet("GetAllApplication")]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetAllApplications()
        {
            var jobApplications = await _appDbContext.JobApply.ToListAsync();
            return Ok(jobApplications);
        }
       
    }
}
