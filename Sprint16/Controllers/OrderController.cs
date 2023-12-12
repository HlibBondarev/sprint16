using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;

namespace Sprint16.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingContext _context;
        public OrderController(ShoppingContext context)
        {
            _context = context;
        }
        public List<Order> Orders { get; set; }
        public Order SelectedOrder { get; set; }
        public async Task<IActionResult> Index(int? id)
        {
            foreach (var order in _context.Orders)
            {
                order.Customers = _context.Customers.Find(order.CustomerId);
                order.Supermarkets = _context.Supermarkets.Find(order.SupermarketId);
            }

            return View(await _context.Orders.ToListAsync());
        }
    }
}
