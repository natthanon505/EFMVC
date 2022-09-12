namespace EFMVC.Models
{
    public class CustomerOrderItem
    {
        public int Id { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}