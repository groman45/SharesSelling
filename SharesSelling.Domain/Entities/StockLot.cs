using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharesSelling.Domain.Entities
{
	public class StockLot
	{
		public int Id { get; set; }		
		public string StockTicker { get; set; }
		public decimal Price { get; set; } 
		public int Count { get; set; } 
		public DateTime Date { get; set; } 
	}
}
