using GS_DTOs.Data;
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
			GSUtility.ValidateString(productDTO.Name, "Invalid product Name !", nameMinLength, nameMaxLength);

			GSUtility.ValidateNumber(productDTO.UnitPrice, "Unit price must be greater than 0.");

			GSUtility.ValidateNumber(productDTO.CategoryId, "Invalid category !");

			GSUtility.ValidateNumber(productDTO.PricingTypeId, "Invalid pricing type !");

			if (productDTO.Quantity < 0)
				throw new ArgumentException("Quantity cannot be negative !");

			if (productDTO.Barcode != "")
				GSUtility.ValidateString(productDTO.Barcode, "Invalid Barcode !", 8);
		}

		public static List<ProductDTO> GetAllProducts(int categoryId)
		{
			GSUtility.ValidateNumber(categoryId, "Invalid Category id");

			return ProductData.GetAllProducts(categoryId);
		}

		public static ProductDTO? GetProductById(int productId)
		{
			GSUtility.ValidateNumber(productId, "Product id must be greater than 0");

			ProductDTO? product = ProductData.GetProductById(productId);

			return product;
		}

		public static ProductDTO? GetProductByBarcod(string barcode)
		{
			GSUtility.ValidateString(barcode, "Invalid Barcode!", barcodeMinLength);

			ProductDTO? product = ProductData.GetProductByBarcode(barcode);

			return product;
		}

		public static ProductDTO? GetProductByName(string productName)
		{
			GSUtility.ValidateString(productName, "Invalid product Name", nameMinLength, nameMaxLength);

			ProductDTO? product = ProductData.GetProductByName(productName);

			return product;
		}

		public static int AddProduct(ProductDTO productDTO)
		{
			GSUtility.ValidateObject(productDTO);

			validateProduct(productDTO);

			return ProductData.AddProduct(productDTO);
		}

		public static int UpdateProduct(ProductDTO productDTO)
		{

			GSUtility.ValidateObject(productDTO);

			GSUtility.ValidateNumber(productDTO.Id, "Product id must be greater than 0");

			validateProduct(productDTO);

			return ProductData.UpdateProduct(productDTO);
		}

		public static List<ProductDTO> GetDeletedProducts()
		{
			return ProductData.GetDeletedProducts();
		}

		public static int DeleteProduct(int productId)
		{
			GSUtility.ValidateNumber(productId, "Product id must be greater than 0");

			return ProductData.DeleteProduct(productId);
		}

		public static int RestoreProduct(int productId)
		{
			GSUtility.ValidateNumber(productId, "Product id must be greater than 0");

			return ProductData.RestoreProduct(productId);
		}
		







	}
}
