using BCrypt.Net;
using GS_Data;
using GS_Data.Data;
using static GS_DTOs.UserDTOs;

namespace GS_Business
{
	public class User
	{
		public static void validateUserDTO(CreateUserDTO dto)
		{
			Validation.ValidateObject(dto);

			Validation.ValidateString(dto.FirstName, "Invalid first name!", 1, 50);

			Validation.ValidateString(dto.LastName, "Invalid last name!", 1, 50);

			Validation.ValidateEmail(dto.Email);

			Validation.ValidateNumber(dto.RoleId, "Invalid role id!");

			Validation.ValidatePassword(dto.Password);
		}

		public static void validateUserDTO(UpdateUserDTO dto)
		{
			Validation.ValidateObject(dto);

			Validation.ValidateNumber(dto.Id, "Invalid user ID!");

			Validation.ValidateString(dto.FirstName, "Invalid first name!", 1, 50);

			Validation.ValidateString(dto.LastName, "Invalid last name!", 1, 50);

			Validation.ValidateEmail(dto.Email);

			Validation.ValidateNumber(dto.RoleId, "Invalid role id!");
		}

		public static UserDTO? Find(int userId)
		{
			Validation.ValidateNumber(userId, "Invalid user ID!");

			return UserData.GetUserById(userId);
		}

		public static List<UserDTO> GetAll()
		{
			return UserData.GetAllUsers();
		}

		public static int AddNew(CreateUserDTO dto)
		{ 
			validateUserDTO(dto);

			dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

			return UserData.AddUser(dto);
		}

		public static int Update(UpdateUserDTO dto)
		{
			validateUserDTO(dto);

			return UserData.UpdateUser(dto);
		}

		public static int Activation(int userId, bool status)
		{
			Validation.ValidateNumber(userId, "Invalid user ID!");

			return UserData.UserActivation(userId, status);
		}





	}
}
