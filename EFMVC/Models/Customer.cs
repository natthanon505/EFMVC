using System.ComponentModel.DataAnnotations;

namespace EFMVC.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Tel { get; set; }

        public List<Order> CustomerOrder { get; set; } = new List<Order>();
        public List<CustomerOrderItem> CustomerCustomerOrderItem { get; set; } = new List<CustomerOrderItem>();

    }
}
