namespace GS_DTOs
{
	public class UpdatedProductDTO : NewProductDTO
	{
		public int Id { get; set; }

		public override ProductDTO ConvertToProductDTO()
		{
			return new ProductDTO
			{
				Id = this.Id,
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
