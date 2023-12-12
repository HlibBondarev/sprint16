using Microsoft.EntityFrameworkCore;
using Sprint16.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.EF
{
	public class ShoppingContext : DbContext
	{
		public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Supermarket> Supermarkets { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=shoppingDb;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>().HasData(
				[
					new Customer { Id = 1, Fname = "Volodya", Lname = "Myk", Address = "Ivano-Frankivsk", Discount = 3 },
					new Customer { Id = 2, Fname = "Hlib", Lname = "Bond", Address = "Dnipro", Discount = 5 },
					new Customer { Id = 3, Fname = "Maksym", Lname = "Seer", Address = "Kyiv", Discount = 4 }
				]);
			modelBuilder.Entity<Product>().HasData(
				[
					new Product { Id = 1, Name = "Butter", Price = 30.0f },
					new Product { Id = 2, Name = "Apple", Price = 20.50f },
					new Product { Id = 3, Name = "Morshinska", Price = 9.30f }
				]);
			modelBuilder.Entity<Supermarket>().HasData(
				[
					new Supermarket { Id = 1, Name = "Atb", Address = "Mazepy str" },
					new Supermarket { Id = 2, Name = "Silpo", Address = "Shevchenka str" },
					new Supermarket { Id = 3, Name = "Comfy", Address = "Parkova str" }
				]);
			modelBuilder.Entity<Order>().HasData(
				[
					new Order { Id = 1, CustomerId = 1, SupermarketId = 1, OrderDate = new DateTime(2023, 3, 4) },
					new Order { Id = 2, CustomerId = 2, SupermarketId = 2, OrderDate = new DateTime(2023, 5, 27) },
					new Order { Id = 3, CustomerId = 3, SupermarketId = 3, OrderDate = new DateTime(2023, 1, 2) }
				]);
			modelBuilder.Entity<OrderDetails>().HasData(
				[
					new OrderDetails { Id = 1, OrderId = 1, ProductId = 1, Quantity = 5 },
					new OrderDetails { Id = 2, OrderId = 2, ProductId = 3, Quantity = 4 },
					new OrderDetails { Id = 3, OrderId = 3, ProductId = 2, Quantity = 1 }
				]);
		}
	}
}
