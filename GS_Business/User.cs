using GS_Data;
using GS_Data.Data;
using static GS_DTOs.UserDTOs;

namespace GS_Business
{
	public class User
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string? Phone { get; set; }

		public string Email { get; set; }

		public int Permissions { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

		public string? ImagePath { get; set; }

		private User(UserDTO dto)
		{
			Id = dto.Id;
			FirstName = dto.FirstName;
			LastName = dto.LastName;
			Phone = dto.Phone;
			Email = dto.Email;
			Permissions = dto.Permissions;
			CreatedAt = dto.CreatedAt;
			UpdatedAt = dto.UpdatedAt;
			ImagePath = dto.ImagePath;
		}

		public static User? Find(int userId)
		{
			GSUtility.ValidateNumber(userId, "Invalid user ID!");

			UserDTO? dto = UserData.GetUserById(userId);

			return dto == null ? null : new User(dto);
		}

		public static List<UserDTO> GetAll()
		{
			return UserData.GetAllUsers();
		}

		public static int Add(CreateUserDTO dto)
		{ 
			return UserData.AddUser(dto);
		}

		public bool Save()
		{
			UpdateUserDTO dto = new UpdateUserDTO
			{
				Id = Id,
				FirstName = FirstName,
				LastName = LastName,
				Phone = Phone,
				Email = Email,
				Permissions = Permissions,
				ImagePath = ImagePath
			};

			return UserData.UpdateUser(dto) > 0;
		}

		public bool Activate(bool status)
		{
			return UserData.UserActivation(Id, status) > 0;

		}
	}
}
