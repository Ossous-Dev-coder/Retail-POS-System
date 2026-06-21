using GS_DTOs;
using GS_DTOs.Data;

namespace GS_Business
{
	public class Category
	{
		public static bool IsExists(int categoryId)
		{
			GSUtility.ValidateNumber(categoryId, "Invalid category id!");

			return CategoryData.IsExists(categoryId);
		}
	}
}
