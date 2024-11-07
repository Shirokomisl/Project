namespace Project.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public User? User { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }
    }
}
