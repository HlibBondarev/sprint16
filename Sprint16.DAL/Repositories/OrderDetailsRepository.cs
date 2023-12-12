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
	internal class OrderDetailsRepository : IRepository<OrderDetails>
	{
		private ShoppingContext db;
		public OrderDetailsRepository(ShoppingContext shoppingContext)
		{
			db = shoppingContext;
		}
		public void Create(OrderDetails item)
		{
			db.OrderDetails.Add(item);
		}

		public void Delete(int id)
		{
			OrderDetails item = db.OrderDetails.Find(id);
			if (item != null)
				db.OrderDetails.Remove(item);
		}

		public IEnumerable<OrderDetails> Find(Func<OrderDetails, bool> predicate)
		{
			return db.OrderDetails.Where(predicate).ToList();
		}

		public OrderDetails Get(int id)
		{
			return db.OrderDetails.Find(id);
		}

		public IEnumerable<OrderDetails> GetAll()
		{
			return db.OrderDetails;
		}

		public void Update(OrderDetails item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
