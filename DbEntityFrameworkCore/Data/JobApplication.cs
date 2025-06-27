namespace DbEntityFrameworkCore.Data
{
    public class JobApplication
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string? MobileNo { get; set; }

        public string Position { get; set; }

        public string Message { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}
