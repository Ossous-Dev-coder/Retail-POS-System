
using Microsoft.Data.SqlClient;
using System.Data;


namespace GS_DTOs.Data
{
	public class StockData
	{
		public static int AddNewStockMovement(MovementDTO movement)
		{
			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_addNewMovement", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@product_id", SqlDbType.Int).Value = movement.ProductId;

			command.Parameters.Add("@movementType_id", SqlDbType.Int).Value = movement.MovementTypeId;

			command.Parameters.Add("@quantity", SqlDbType.Decimal).Value = movement.Quantity;

			connection.Open();

			object result = command.ExecuteScalar();

			return Convert.ToInt32(result);
		}

		public static List<MovementDTO> GetMovements(int pageNumber, int rowsPerPage, DateTime? fromDate = null, DateTime? toDate = null, int? productId = null, int? movementTypeId = null)
		{
			List<MovementDTO> list = new List<MovementDTO>();

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
			using SqlCommand command = new SqlCommand("SP_getMovements", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@pageNumber", SqlDbType.Int).Value = pageNumber;
			command.Parameters.Add("@rowsPerPage", SqlDbType.Int).Value = rowsPerPage;

			command.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value = (object?)fromDate ?? DBNull.Value;

			command.Parameters.Add("@toDate", SqlDbType.DateTime2).Value = (object?)toDate ?? DBNull.Value;

			
			command.Parameters.Add("@product_id", SqlDbType.Int).Value = (object?)productId ?? DBNull.Value;

			command.Parameters.Add("@movementType_id", SqlDbType.Int).Value = (object?)movementTypeId ?? DBNull.Value;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				list.Add(new MovementDTO
				{
					Id = reader.GetInt32(reader.GetOrdinal("id")),
					CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdAt")),
					Quantity = reader.GetDecimal(reader.GetOrdinal("quantity")),

					ProductId = reader.GetInt32(reader.GetOrdinal("product_id")),
					ProductName = reader.GetString(reader.GetOrdinal("productName")),

					MovementTypeId = reader.GetInt32(reader.GetOrdinal("movementType_id")),
					MovementTypeName = reader.GetString(reader.GetOrdinal("typeName"))
				});
			}
			

			return list;
		}


	}
}
