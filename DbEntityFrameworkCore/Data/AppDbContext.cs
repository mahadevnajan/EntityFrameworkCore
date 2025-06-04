using Microsoft.EntityFrameworkCore;

namespace DbEntityFrameworkCore.Data
{
    public class AppDbContext :DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
    }
}
