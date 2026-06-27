using GS_Data;
using GS_Data.Data;
using static GS_DTOs.UserDTOs;

namespace GS_Business
{
	public class User
	{
		public static void validateUserDTO(CreateUserDTO dto)
		{
			GSUtility.ValidateObject(dto);

			GSUtility.ValidateString(dto.FirstName, "Invalid first name!", 1, 50);

			GSUtility.ValidateString(dto.LastName, "Invalid last name!", 1, 50);

			GSUtility.ValidateEmail(dto.Email);

			GSUtility.ValidateNumber(dto.Permissions, "Invalid permissions!");
		}

		public static void validateUserDTO(UpdateUserDTO dto)
		{
			GSUtility.ValidateObject(dto);

			GSUtility.ValidateNumber(dto.Id, "Invalid user ID!");

			GSUtility.ValidateString(dto.FirstName, "Invalid first name!", 1, 50);

			GSUtility.ValidateString(dto.LastName, "Invalid last name!", 1, 50);

			GSUtility.ValidateEmail(dto.Email);

			GSUtility.ValidateNumber(dto.Permissions, "Invalid permissions!");
		}

		public static UserDTO? Find(int userId)
		{
			GSUtility.ValidateNumber(userId, "Invalid user ID!");

			return UserData.GetUserById(userId);
		}

		public static List<UserDTO> GetAll()
		{
			return UserData.GetAllUsers();
		}

		public static int AddNew(CreateUserDTO dto)
		{ 
			validateUserDTO(dto);

			return UserData.AddUser(dto);
		}

		public static int Update(UpdateUserDTO dto)
		{
			validateUserDTO(dto);

			return UserData.UpdateUser(dto);
		}

		public static int Activation(int userId, bool status)
		{
			GSUtility.ValidateNumber(userId, "Invalid user ID!");

			return UserData.UserActivation(userId, status);
		}





	}
}
