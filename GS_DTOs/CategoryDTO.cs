using System;
using System.Collections.Generic;
using System.Text;

namespace GS_DTOs
{
	public class CategoryDTO
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

		public string? ImagePath { get; set; }


	}
}
