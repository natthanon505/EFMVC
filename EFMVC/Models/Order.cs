using System.ComponentModel.DataAnnotations;

namespace EFMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<CustomerOrderItem> OrderCustomerOrderItem { get; set; } = new List<CustomerOrderItem>();



    }
}
