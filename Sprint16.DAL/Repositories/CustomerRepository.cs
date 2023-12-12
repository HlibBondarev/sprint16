using Microsoft.EntityFrameworkCore;
using Sprint16.DAL.EF;
using Sprint16.DAL.Entities;
using Sprint16.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Repositories
{
	public class CustomerRepository : IRepository<Customer>
	{
		private ShoppingContext db;	
		public CustomerRepository(ShoppingContext shoppingContext) 
		{
			db = shoppingContext;
		}
		public void Create(Customer item)
		{
			db.Customers.Add(item);
		}

		public void Delete(int id)
		{
			Customer item = db.Customers.Find(id);
			if (item != null)
				db.Customers.Remove(item);
		}

		public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
		{
			return db.Customers.Where(predicate).ToList();
		}

		public Customer Get(int id)
		{
			return db.Customers.Find(id);
		}

		public IEnumerable<Customer> GetAll()
		{
			return db.Customers;
		}

		public void Update(Customer item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
