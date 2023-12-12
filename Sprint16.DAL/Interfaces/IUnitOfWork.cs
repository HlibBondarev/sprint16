using Sprint16.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Customer> Customers { get; }
		IRepository<Product> Products { get; }
		IRepository<Supermarket> Supermarkets { get; }
		IRepository<Order> Orders { get; }
		IRepository<OrderDetails> OrderDetails { get; }
		void Save();
	}
}
