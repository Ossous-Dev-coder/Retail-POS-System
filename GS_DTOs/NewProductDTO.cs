using System;
using System.Collections.Generic;
using System.Text;
using GS_DTOs;

namespace GS_DTOs
{
	public class NewProductDTO
	{
		public string Name { get; set; } = string.Empty;

		public string? Barcode { get; set; }

		public string? Description { get; set; }

		public decimal UnitPrice { get; set; }

		public int Quantity { get; set; }

		public int CategoryId { get; set; }

		public int PricingTypeId { get; set; }

		public string? ImagePath { get; set; }

		public virtual ProductDTO ConvertToProductDTO()
		{
			return new ProductDTO
			{
				Name = this.Name,
				Barcode = this.Barcode,
				Description = this.Description,
				UnitPrice = this.UnitPrice,
				Quantity = this.Quantity,
				CategoryId = this.CategoryId,
				PricingTypeId = this.PricingTypeId,
				ImagePath = this.ImagePath
			};
		}
	}
}
