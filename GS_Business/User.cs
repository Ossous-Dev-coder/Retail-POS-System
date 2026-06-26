using GS_Data;
using GS_Data.Data;
using static GS_DTOs.UserDTOs;

namespace GS_Business
{
	public class User
	{

		public static UserDTO? Find(int userId)
		{
			GSUtility.ValidateNumber(userId, "Invalid user ID!");

			return UserData.GetUserById(userId);
		}

		public static List<UserDTO> GetAll()
		{
			return UserData.GetAllUsers();
		}

		public static int Add(CreateUserDTO dto)
		{ 
			return UserData.AddUser(dto);
		}

		public static int Update(UpdateUserDTO dto)
		{
			return UserData.UpdateUser(dto);
		}




	}
}
