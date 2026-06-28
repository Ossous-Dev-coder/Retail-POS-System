using GS_Data;
using GS_Data.Data;

namespace GS_Business
{
	public class Category
	{
		public static bool IsExists(int categoryId)
		{
			Validation.ValidateNumber(categoryId, "Invalid category id!");

			return CategoryData.IsExists(categoryId);
		}
	}
}
