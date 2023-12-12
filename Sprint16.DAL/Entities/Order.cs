using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int SupermarketId { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime OrderDate { get; set; }

		public Customer Customers { get; set; }
		public Supermarket Supermarkets { get; set; }

		public ICollection<OrderDetails> OrderDetails { get; set; }
	}
}
