using System;
using System.Collections.Generic;
using System.Text;

namespace GS_DTOs
{
	public class MovementDTO
	{
		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public decimal Quantity { get; set; }

		public int ProductId { get; set; }

		public string? ProductName { get; set; }

		public int MovementTypeId { get; set; }

		public string? MovementTypeName { get; set; }
		
	}
}
