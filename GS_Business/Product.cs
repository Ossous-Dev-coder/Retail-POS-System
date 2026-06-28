using GS_Data;
using GS_Data.Data;
using GS_DTOs;

namespace GS_Business
{
	public class Product
	{
		static int nameMinLength = 3;

		static int nameMaxLength = 50;

		static int barcodeMinLength = 3;


		private static void validateProduct(ProductDTO productDTO)
		{
			Validation.ValidateString(productDTO.Name, "Invalid product Name !", nameMinLength, nameMaxLength);

			Validation.ValidateNumber(productDTO.UnitPrice, "Unit price must be greater than 0.");

			Validation.ValidateNumber(productDTO.CategoryId, "Invalid category !");

			Validation.ValidateNumber(productDTO.PricingTypeId, "Invalid pricing type !");

			if (productDTO.Quantity < 0)
				throw new ArgumentException("Quantity cannot be negative !");

			if (productDTO.Barcode != "")
				Validation.ValidateString(productDTO.Barcode, "Invalid Barcode !", 8);
		}

		public static List<ProductDTO> GetAllProducts(int categoryId)
		{
			Validation.ValidateNumber(categoryId, "Invalid Category id");

			return ProductData.GetAllProducts(categoryId); 
		}

		public static ProductDTO? GetProductById(int productId)
		{
			Validation.ValidateNumber(productId, "Product id must be greater than 0");

			ProductDTO? product = ProductData.GetProductById(productId);

			return product;
		}

		public static ProductDTO? GetProductByBarcod(string barcode)
		{
			Validation.ValidateString(barcode, "Invalid Barcode!", barcodeMinLength);

			ProductDTO? product = ProductData.GetProductByBarcode(barcode);

			return product;
		}

		public static ProductDTO? GetProductByName(string productName)
		{
			Validation.ValidateString(productName, "Invalid product Name", nameMinLength, nameMaxLength);

			ProductDTO? product = ProductData.GetProductByName(productName);

			return product;
		}

		public static int AddProduct(ProductDTO productDTO)
		{
			Validation.ValidateObject(productDTO);

			validateProduct(productDTO);

			return ProductData.AddProduct(productDTO);
		}

		public static int UpdateProduct(ProductDTO productDTO)
		{

			Validation.ValidateObject(productDTO);

			Validation.ValidateNumber(productDTO.Id, "Product id must be greater than 0");

			validateProduct(productDTO);

			return ProductData.UpdateProduct(productDTO);
		}

		public static List<ProductDTO> GetDeletedProducts()
		{
			return ProductData.GetDeletedProducts();
		}

		public static int DeleteProduct(int productId)
		{
			Validation.ValidateNumber(productId, "Product id must be greater than 0");

			return ProductData.DeleteProduct(productId);
		}

		public static int RestoreProduct(int productId)
		{
			Validation.ValidateNumber(productId, "Product id must be greater than 0");

			return ProductData.RestoreProduct(productId);
		}
		







	}
}
