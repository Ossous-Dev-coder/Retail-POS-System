using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static GS_DTOs.UserDTOs;

namespace GS_Data.Data
{
	public class UserData
	{
		public int AddUser(CreateUserDTO user)
		{
			using SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
			using SqlCommand cmd = new SqlCommand("SP_AddNewUser", conn);

			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Value = user.FirstName;
			cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50).Value = user.LastName;

			cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20).Value = (object?)user.Phone ?? DBNull.Value;

			cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = user.Email;
			cmd.Parameters.Add("@passwordHash", SqlDbType.VarChar, 255).Value = user.PasswordHash;
			cmd.Parameters.Add("@hashSalt", SqlDbType.VarChar, 255).Value = user.HashSalt;

			cmd.Parameters.Add("@permissions", SqlDbType.Int).Value = user.Permissions;

			cmd.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = (object?)user.ImagePath ?? DBNull.Value;

			conn.Open();

			object result = cmd.ExecuteScalar();

			return Convert.ToInt32(result);
		}

		public int UpdateUser(UpdateUserDTO user)
		{
			using SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
			using SqlCommand cmd = new SqlCommand("SP_UpdateUser", conn);

			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.Id;

			cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Value = user.FirstName;
			cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50).Value = user.LastName;

			cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20).Value = (object?)user.Phone ?? DBNull.Value;

			cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = user.Email;

			cmd.Parameters.Add("@permissions", SqlDbType.Int).Value = user.Permissions;

			cmd.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = (object?)user.ImagePath ?? DBNull.Value;

			conn.Open();

			return cmd.ExecuteNonQuery();
		}

		public UserDTO? GetUserById(int id)
		{
			using SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
			using SqlCommand cmd = new SqlCommand("SP_GetUserById", conn);

			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

			conn.Open();

			using SqlDataReader reader = cmd.ExecuteReader();

			if (!reader.Read())
				return null;

			return new UserDTO
			{
				Id = reader.GetInt32(reader.GetOrdinal("id")),
				FirstName = reader.GetString(reader.GetOrdinal("firstName")), 
				LastName = reader.GetString(reader.GetOrdinal("lastName")),
				Email = reader.GetString(reader.GetOrdinal("email")),
				Permissions = reader.GetInt32(reader.GetOrdinal("permissions")),
				CreatedAt = reader.GetDateTime(reader.GetOrdinal("createdAt")),

				UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updatedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("updatedAt")),

				Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null: reader.GetString(reader.GetOrdinal("phone")),

				ImagePath = reader.IsDBNull(reader.GetOrdinal("imagePath")) ? null: reader.GetString(reader.GetOrdinal("imagePath"))
			};
		}

		public int UserActivation(int id, bool status)
		{
			using SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
			using SqlCommand cmd = new SqlCommand("SP_ChangeActivationStatus", conn);

			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
			cmd.Parameters.Add("@activationStatus", SqlDbType.Bit).Value = status;

			conn.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
