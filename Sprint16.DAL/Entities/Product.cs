using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Entities
{
	public class Product
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		public float Price { get; set; }

		public ICollection<OrderDetails> OrderDetails { get; set; }
	}
}
