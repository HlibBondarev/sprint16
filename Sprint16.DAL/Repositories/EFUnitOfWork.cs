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
	public class EFUnitOfWork : IUnitOfWork
	{
		private ShoppingContext db;
		private CustomerRepository customerRepository;
		private ProductRepository productRepository;
		private SupermarketRepository supermarketRepository;
		private OrderRepository orderRepository;
		private OrderDetailsRepository orderDetailsRepository;

		//public EFUnitOfWork(string connectionString)
		//{
		//	db = new ShoppingContext(connectionString);
		//}
		public IRepository<Customer> Customers
		{
			get
			{
				if (customerRepository == null)
					customerRepository = new CustomerRepository(db);
				return customerRepository;
			}
		}

		public IRepository<Product> Products
		{
			get
			{
				if (productRepository == null)
					productRepository = new ProductRepository(db);
				return productRepository;
			}
		}

		public IRepository<Supermarket> Supermarkets
		{
			get
			{
				if (supermarketRepository == null)
					supermarketRepository = new SupermarketRepository(db);
				return supermarketRepository;
			}
		}

		public IRepository<Order> Orders
		{
			get
			{
				if (orderRepository == null)
					orderRepository = new OrderRepository(db);
				return orderRepository;
			}
		}

		public IRepository<OrderDetails> OrderDetails
		{
			get
			{
				if (orderDetailsRepository == null)
					orderDetailsRepository = new OrderDetailsRepository(db);
				return orderDetailsRepository;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
