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
	internal class SupermarketRepository : IRepository<Supermarket>
	{
		private ShoppingContext db;
		public SupermarketRepository(ShoppingContext shoppingContext)
		{
			db = shoppingContext;
		}
		public void Create(Supermarket item)
		{
			db.Supermarkets.Add(item);
		}

		public void Delete(int id)
		{
			Supermarket item = db.Supermarkets.Find(id);
			if (item != null)
				db.Supermarkets.Remove(item);
		}

		public IEnumerable<Supermarket> Find(Func<Supermarket, bool> predicate)
		{
			return db.Supermarkets.Where(predicate).ToList();
		}

		public Supermarket Get(int id)
		{
			return db.Supermarkets.Find(id);
		}

		public IEnumerable<Supermarket> GetAll()
		{
			return db.Supermarkets;
		}

		public void Update(Supermarket item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
