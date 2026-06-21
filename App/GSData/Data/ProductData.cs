using Microsoft.Data.SqlClient;
using System.Data;

namespace GS_DTOs.Data
{
	public class ProductData
	{
		static void setParameters(SqlCommand command,  ProductDTO productDTO)
		{

			command.Parameters.Add("@productName", SqlDbType.VarChar, 50).Value = productDTO.Name == "" ? null : productDTO.Name;
			command.Parameters.Add("@category_id", SqlDbType.Int).Value = productDTO.CategoryId;
			command.Parameters.Add("@pricingType_id", SqlDbType.Int).Value = productDTO.PricingTypeId;

			//UnitPrice
			SqlParameter unitPriceParameter = command.Parameters.Add("@unitPrice", SqlDbType.Decimal);
			unitPriceParameter.Precision = 11;
			unitPriceParameter.Scale = 2;
			unitPriceParameter.Value = productDTO.UnitPrice;

			//Quantity
			SqlParameter quantityParameter = command.Parameters.Add("@quantity", SqlDbType.Decimal);
			quantityParameter.Precision = 11;
			quantityParameter.Scale = 2;
			quantityParameter.Value = productDTO.Quantity;

			command.Parameters.Add("@productBarcode", SqlDbType.VarChar, 50).Value = (object?)productDTO.Barcode ?? DBNull.Value;
			command.Parameters.Add("@description", SqlDbType.VarChar, 200).Value = (object?)productDTO.Description ?? DBNull.Value;
			command.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = GSUtility.SetImagePath(productDTO.ImagePath);
		}

		static ProductDTO loadProduct(SqlDataReader reader)
		{
			return new ProductDTO
			{

				Id = reader.GetInt32("id"),

				Barcode = reader.IsDBNull("barCode") ? string.Empty : reader.GetString("barCode"),

				Name = reader.GetString("name"),

				Description = reader.IsDBNull("description") ? string.Empty : reader.GetString("description"),

				UnitPrice = reader.GetDecimal("unitPrice"),

				Quantity = reader.GetDecimal("quantity"),

				PricingTypeId = reader.GetInt32("pricingType_id"),

				PricingTypeName = reader.GetString("pricingTypeName"),

				ImagePath = reader.IsDBNull("imagePath") ? string.Empty : reader.GetString("imagePath"),

				CategoryId = reader.GetInt32("category_id"),

				CategoryName = reader.GetString("categoryName"),

				CreatedAt = reader.GetDateTime("createdAt"),

				UpdatedAt = reader.IsDBNull("updatedAt") ? null : reader.GetDateTime("updatedAt")
			};
		}

		public static List<ProductDTO> GetAllProducts(int categoryId)
		{
			GSUtility.ValidateNumber(categoryId, "Invalid category id!");

			List<ProductDTO> productsDTOs = new List<ProductDTO>();

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_getAllProducts", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();


			while (reader.Read())
			
				productsDTOs.Add(loadProduct(reader));  
			
			return productsDTOs;
		}

		public static ProductDTO? GetProductById(int productId)
		{
			GSUtility.ValidateNumber(productId, "Invalid product id!");

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_getProduct", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@product_id", SqlDbType.Int).Value = productId;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();

			if (reader.Read())

				return loadProduct(reader);

			return null;
		}

		public static ProductDTO? GetProductByBarcode(string barcode)
		{
			GSUtility.ValidateString(barcode, "Invalid barcode");

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_getProductByBarcode", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@barcode", SqlDbType.VarChar, 50).Value = barcode;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();

			if (reader.Read())

				return loadProduct(reader);

			return null;
		}

		public static ProductDTO? GetProductByName(string productName)
		{
			GSUtility.ValidateString(productName, "Invalid product name");

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_getProductByName", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@productName", SqlDbType.VarChar, 50).Value = productName;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();

			if (reader.Read())

				return loadProduct(reader);

			return null;
		}

		public static int AddProduct(ProductDTO productDTO)
		{
			GSUtility.ValidateObject(productDTO);

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_addNewProduct", connection);

			command.CommandType = CommandType.StoredProcedure;

			setParameters(command, productDTO);

			connection.Open();

			object result = command.ExecuteScalar();

			return Convert.ToInt32(result);
		}

		public static int UpdateProduct(ProductDTO productDTO)
		{
			GSUtility.ValidateObject(productDTO);

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_updateProduct", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@product_id", SqlDbType.Int).Value = productDTO.Id;

			setParameters(command, productDTO);

			connection.Open();

			return command.ExecuteNonQuery();
		}

		public static List<ProductDTO> GetDeletedProducts()
		{
			List<ProductDTO> productsDTOs = new List<ProductDTO>();

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_getDeletedProducts", connection);

			command.CommandType = CommandType.StoredProcedure;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();


			while (reader.Read())

				productsDTOs.Add(loadProduct(reader));

			return productsDTOs;
		}

		public static int DeleteProduct(int productId)
		{
			GSUtility.ValidateNumber(productId, "Invalid product id");

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_deleteProduct", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@product_id", SqlDbType.Int).Value = productId;

			connection.Open();

			return command.ExecuteNonQuery();
		}

		public static int RestoreProduct(int productId)
		{
			GSUtility.ValidateNumber(productId, "Invalid product id");

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_restoreProduct", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@product_id", SqlDbType.Int).Value = productId;

			connection.Open();

			return command.ExecuteNonQuery();
		}
	}
}
