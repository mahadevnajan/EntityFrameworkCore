namespace DbEntityFrameworkCore.Data
{
    public class Login
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } 

        public string Password { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;


    }
}
