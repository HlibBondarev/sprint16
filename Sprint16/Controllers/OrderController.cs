using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;
using Sprint16.Service;
using Sprint16.Repository;
using Sprint16.Models.ViewModels;

namespace Sprint16.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingContext _context;
        private readonly UnitOfWork unitOfWork;

        public OrderController(ShoppingContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
        public async Task<IActionResult> Index(int id, int orderId)
        {
            var viewModel = new OrderIndexData();
            viewModel.Orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Include(c => c.Customers)
                .Include(s => s.Supermarkets)
                .ToListAsync();
            viewModel.OrderDetails = await _context.OrderDetails
                .Include(p => p.Product)
                .Include(o => o.Order)
                .ToListAsync();

            //if (id != null)
            //{
            //    ViewData["OrderId"] = id.Value;
            //    Order order = viewModel.Orders.Where(i => i.Id == id.Value).Single();
            //}
            return View(viewModel);
            //foreach (var order in _context.OrderDetails)
            //{
            //    order.Product = await unitOfWork.Products.Get(order.ProductId);
            //    order.Order = await unitOfWork.Orders.Get(order.OrderId);
            //}
            //foreach (var item in _context.Orders)
            //{
            //    item.Customers = await unitOfWork.Customers.Get(item.CustomerId);
            //    item.Supermarkets = await unitOfWork.Supermarkets.Get(item.SupermarketId);
            //}

            //return View(await Order.ToListAsync());
        }
        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Order order)
        //{
        //    return View(order);
        //}
        //public async Task<IActionResult> Edit(int id)
        //{
        //    Order order = _context.Orders.Find(id);
        //    if (order != null)
        //    {
        //        return View(order);
        //    }

        //    return View("NotExists");
        //}
        //public async Task<IActionResult> Delete(int id)
        //{
        //    _context.Orders.Remove(_context.Orders.Find(id));
        //    _context.SaveChanges();
        //    return View();
        //}
        public async Task<IActionResult> View(int id)
        {
            OrderDetails orderDetails = _context.OrderDetails.Find();

            if (ModelState.IsValid)
            {
                return View(orderDetails);
            }

            return View("NotExists");
        }
    }
}
