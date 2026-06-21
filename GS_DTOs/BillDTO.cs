using System;
using System.Collections.Generic;
using System.Text;

namespace GS_DTOs
{
	public class BillDTO
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public decimal TotalPrice { get; set; }
		public int PaymentMethodId { get; set; }
		public string? PaymentMethodName { get; set; }
		public int BillStatusId { get; set; }
		public string? BillStatusName { get; set; }
		
	}
}
