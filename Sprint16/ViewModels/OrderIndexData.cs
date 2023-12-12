using Microsoft.AspNetCore.Mvc;
using Sprint16.Models;

namespace Sprint16.Models.ViewModels
{
    public class OrderIndexData()
    {
        public IEnumerable<Order> Orders { get; set; }
        //public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
