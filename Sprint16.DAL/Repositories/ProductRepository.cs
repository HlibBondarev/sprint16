﻿using Microsoft.EntityFrameworkCore;
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
	internal class ProductRepository : IRepository<Product>
	{
		private ShoppingContext db;
		public ProductRepository(ShoppingContext shoppingContext)
		{
			db = shoppingContext;
		}
		public void Create(Product item)
		{
			db.Products.Add(item);
		}

		public void Delete(int id)
		{
			Product item = db.Products.Find(id);
			if (item != null)
				db.Products.Remove(item);
		}

		public IEnumerable<Product> Find(Func<Product, bool> predicate)
		{
			return db.Products.Where(predicate).ToList();
		}

		public Product Get(int id)
		{
			return db.Products.Find(id);
		}

		public IEnumerable<Product> GetAll()
		{
			return db.Products;
		}

		public void Update(Product item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}