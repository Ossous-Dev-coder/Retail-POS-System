using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GS_DTOs
{
	public class ProductDTO
	{
		public int Id { get; set; }

		public string? Barcode { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal Quantity { get; set; }

		public string? ImagePath { get; set; }

		public int CategoryId { get; set; }

		public string? CategoryName { get; set; }

		public int PricingTypeId { get; set; }

		public string? PricingTypeName { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

	}

}
