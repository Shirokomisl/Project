namespace Project.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Order>? Orders { get; set; }
    }
}
