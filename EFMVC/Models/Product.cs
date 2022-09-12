using System.ComponentModel.DataAnnotations;

namespace EFMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<CustomerOrderItem> ProductCustomerOrderItem { get; set; } = new List<CustomerOrderItem>();



    }
}
