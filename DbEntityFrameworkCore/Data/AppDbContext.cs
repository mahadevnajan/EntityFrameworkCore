using Microsoft.EntityFrameworkCore;

namespace DbEntityFrameworkCore.Data
{
    public class AppDbContext :DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        //below method is used to create a master table in c# i.e OnModelCreating ..
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency() { Id = 2, Title = "Doller", Description = "Doller" },
                new Currency() { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency() { Id = 4, Title = "Diner", Description = "Diner" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "India Mostly Used Language" },
                new Language() { Id = 2, Title = "Tamil", Description = "Tamil" },
                new Language() { Id = 3, Title = "Marathi", Description = "Hindu Marashtra Language" },
                new Language() { Id = 4, Title = "English", Description = "Professional Language" }
                );
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book> Languages { get; set; }
        public DbSet<BookPrice> BookPrices {  get; set; }

        public DbSet<Currency?>Currencies { get; set; }

    }
}
