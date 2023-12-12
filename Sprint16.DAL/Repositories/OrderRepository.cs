using Microsoft.EntityFrameworkCore;
using Sprint16.DAL.EF;
using Sprint16.DAL.Entities;
using Sprint16.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Repositories
{
	internal class OrderRepository : IRepository<Order>
	{
		private ShoppingContext db;
		public OrderRepository(ShoppingContext shoppingContext)
		{
			db = shoppingContext;
		}
		public void Create(Order item)
		{
			db.Orders.Add(item);
		}

		public void Delete(int id)
		{
			Order item = db.Orders.Find(id);
			if (item != null)
				db.Orders.Remove(item);
		}

		public IEnumerable<Order> Find(Func<Order, bool> predicate)
		{
			return db.Orders.Where(predicate).ToList();
		}

		public Order Get(int id)
		{
			return db.Orders.Find(id);
		}

		public IEnumerable<Order> GetAll()
		{
			return db.Orders;
		}

		public void Update(Order item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
