using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.Repository;

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
        public async Task<IActionResult> Index(int? id)
        {
            //var order = await _context.Orders
            //    .Include(od => od.OrderDetails)
            //        .ThenInclude(p => p.Product)
            //        .AsNoTracking()
            //        .ToListAsync();
            //if (order == null)
            //    return NotFound();

            //return View(order);
            return View(await _context.Orders.Include(c => c.Customers).Include(s => s.Supermarkets).ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var order = await _context.Orders
                .Where(o => o.Id == id)
                .Include(od => od.OrderDetails)
                    .ThenInclude(p => p.Product)
                    .AsNoTracking()
                    .ToListAsync();
            if (order == null)
                return NotFound();

            return View(order);
        }
        public IActionResult View()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await unitOfWork.Orders.Create(order);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(order);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            try
            {
                await unitOfWork.Orders.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(order);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var orderToUpdate = await unitOfWork.Orders.Get(id);

            return View(orderToUpdate);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                await unitOfWork.Orders.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditDetails(OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await unitOfWork.OrdersDetails.Update(orderDetails);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(orderDetails);
        }
        public async Task<IActionResult> EditDetails(int id)
        {
            var orderToUpdate = await unitOfWork.OrdersDetails.Get(id);

            return View(orderToUpdate);
        }
        public async Task<IActionResult> DeleteDetails(int id)
        {
            if (id != 0)
            {
                await unitOfWork.OrdersDetails.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
