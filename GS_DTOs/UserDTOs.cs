using System;
using System.Collections.Generic;
using System.Text;

namespace GS_DTOs
{
	public class UserDTOs
	{
		public class UserBaseDTO
		{
			public string FirstName { get; set; } = string.Empty;

			public string LastName { get; set; } = string.Empty;

			public string? Phone { get; set; }

			public string Email { get; set; } = string.Empty;

			public int Permissions { get; set; }

			public string? ImagePath { get; set; }
		}

		public class CreateUserDTO : UserBaseDTO
		{
			public string PasswordHash { get; set; } = string.Empty;

			public string HashSalt { get; set; } = string.Empty;
		}

		public class UserDTO : UserBaseDTO
		{
			public int Id { get; set; }

			public DateTime CreatedAt { get; set; }

			public DateTime? UpdatedAt { get; set; }

		}

		public class UpdateUserDTO : UserBaseDTO
		{
			public int Id { get; set; }

		}
		

	}
}
