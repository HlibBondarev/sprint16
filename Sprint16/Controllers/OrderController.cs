using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;
using Sprint16.Service;

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

            Order order = _context.Orders.Include(o => o.Customers).FirstOrDefault(o => o.CustomerId == id);

            return View(await _context.Orders.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            return View(order);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Order order = _context.Orders.Find(id);
            if (order != null)
            {
                return View(order);
            }

            return View("NotExists");
        }
        public async Task<IActionResult> Delete(int id)
        {
            _context.Orders.Remove(_context.Orders.Find(id));
            _context.SaveChanges();
            return View();
        }
        public async Task<IActionResult> View(int id)
        {
            Order order = _context.Orders.Find(id);
            if (order != null)
            {
                return View(order);
            }

            return View("NotExists");
        }
    }
}
