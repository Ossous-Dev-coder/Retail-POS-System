using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using GS_DTOs;

namespace GS_Data.Data
{
	public class CategoryData
	{
		static CategoryDTO loadCategory(SqlDataReader reader)
		{
			return new CategoryDTO
			{
				Id = reader.GetInt32("id"),

				Name = reader.GetString("name"),

				Description = reader.IsDBNull("description") ? string.Empty : reader.GetString("description"),

				ImagePath = reader.IsDBNull("imagePath") ? string.Empty : reader.GetString("imagePath"),

				CreatedAt = reader.GetDateTime("createdAt"),

				UpdatedAt = reader.IsDBNull("updatedAt") ? null : reader.GetDateTime("updatedAt")
			};
		}

		public static List<CategoryDTO> GetAllCategories()
		{
			List<CategoryDTO> categoriesDTOs = new List<CategoryDTO>();

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_getAllCategories", connection);

			command.CommandType = CommandType.StoredProcedure;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();


			while (reader.Read())

				categoriesDTOs.Add(loadCategory(reader));

			return categoriesDTOs;
		}

		public static int AddCategory(CategoryDTO categoryDTO)
		{
			GSUtility.ValidateObject(categoryDTO);

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_addNewCategory", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = categoryDTO.Name;
			command.Parameters.Add("@description", SqlDbType.VarChar, 200).Value = categoryDTO.Description;
			command.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = GSUtility.SetImagePath(categoryDTO.ImagePath);

			connection.Open();

			int result = GSUtility.IntToStr(command.ExecuteScalar().ToString());

			return result;
		}

		public static int UpdateCategory(CategoryDTO categoryDTO)
		{
			GSUtility.ValidateObject(categoryDTO);

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_updateCategory", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@id", SqlDbType.Int).Value = categoryDTO.Id;
			command.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = categoryDTO.Name;
			command.Parameters.Add("@description", SqlDbType.VarChar, 200).Value = categoryDTO.Description;
			command.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = GSUtility.SetImagePath(categoryDTO.ImagePath);

			connection.Open();

			return command.ExecuteNonQuery();
		}

		public static bool IsExists(int categoryId)
		{
			GSUtility.ValidateNumber(categoryId, "Invalid category id!");

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_isCategoryExists", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;

			connection.Open();

			object? result = command.ExecuteScalar();

			return result != null;
		}
	}
}
