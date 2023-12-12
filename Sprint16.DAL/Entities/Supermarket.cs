using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint16.DAL.Entities
{
	public class Supermarket
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
