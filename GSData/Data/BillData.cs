using Microsoft.Data.SqlClient;
using System.Data;
using GS_DTOs;


namespace GS_Data.Data
{
	public class BillData
	{
		public static int AddBill(decimal totalPrice, int paymentMethodId, int billStatusId)
		{
			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_AddBill", connection);

			command.CommandType = CommandType.StoredProcedure;

			var pTotal = command.Parameters.Add("@totalPrice", SqlDbType.Decimal);
			pTotal.Value = totalPrice;
			pTotal.Precision = 11;
			pTotal.Scale = 2;

			command.Parameters.Add("@paymentMethod_id", SqlDbType.Int).Value = paymentMethodId;
			command.Parameters.Add("@billStatus_id", SqlDbType.Int).Value = billStatusId;

			connection.Open();

			return Convert.ToInt32(command.ExecuteScalar());
		}

		public static int UpdateBill(int id, decimal totalPrice, int paymentMethodId, int billStatusId)
		{
			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_UpdateBill", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@id", SqlDbType.Int).Value = id;

			var pTotal = command.Parameters.Add("@totalPrice", SqlDbType.Decimal);
			pTotal.Value = totalPrice;
			pTotal.Precision = 11;
			pTotal.Scale = 2;

			command.Parameters.Add("@paymentMethod_id", SqlDbType.Int).Value = paymentMethodId;
			command.Parameters.Add("@billStatus_id", SqlDbType.Int).Value = billStatusId;

			connection.Open();

			return command.ExecuteNonQuery();
		}

		public static List<BillDTO> GetBills(int pageNumber, int rowsPerPage, DateTime? fromDate = null, DateTime? toDate = null, int? paymentMethodId = null, int? billStatusId = null)
		{
			List<BillDTO> list = new List<BillDTO>();

			using SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);

			using SqlCommand command = new SqlCommand("SP_GetBills", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@pageNumber", SqlDbType.Int).Value = pageNumber;

			command.Parameters.Add("@rowsPerPage", SqlDbType.Int).Value = rowsPerPage;

			command.Parameters.Add("@fromDate", SqlDbType.DateTime2).Value = (object?)fromDate ?? DBNull.Value;

			command.Parameters.Add("@toDate", SqlDbType.DateTime2).Value = (object?)toDate ?? DBNull.Value;

			command.Parameters.Add("@paymentMethod_id", SqlDbType.Int).Value = (object?)paymentMethodId ?? DBNull.Value;

			command.Parameters.Add("@billStatus_id", SqlDbType.Int).Value = (object?)billStatusId ?? DBNull.Value;

			connection.Open();

			using SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				list.Add(new BillDTO
				{
					Id = (int)reader["id"],
					CreatedAt = (DateTime)reader["createdAt"],
					UpdatedAt = reader["updatedAt"] == DBNull.Value ? null : (DateTime?)reader["updatedAt"],
					TotalPrice = (decimal)reader["totalPrice"],
					PaymentMethodId = (int)reader["paymentMethod_id"],
					PaymentMethodName = reader["methodName"].ToString(),
					BillStatusId = (int)reader["billStatus_id"],
					BillStatusName = reader["statusName"].ToString()
				});
			}

			return list;
		}
	}
}
