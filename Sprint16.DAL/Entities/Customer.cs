using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Entities
{
	public class Customer
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Fname { get; set; }
		[MaxLength(50)]
		public string Lname { get; set; }
		[MaxLength(50)]
		public string Address { get; set; }
		public int Discount { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
