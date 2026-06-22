using System.Text.RegularExpressions;

namespace GS_Data
{
	public class GSUtility
	{
		static public void ValidateNumber(int value, string errorMessage)
		{
			if (value <= 0)

				throw new ArgumentException(errorMessage);
		}

		static public void ValidateNumber(decimal value, string errorMessage)
		{
			if (value <= 0)

				throw new ArgumentException(errorMessage);
		}

		static public void ValidateString(string? value, string errorMessage, int minLength = 0, int maxLength = 10000)
		{
			if (string.IsNullOrWhiteSpace(value) ||
				value.Length < minLength ||
				value.Length > maxLength ||
				!Regex.IsMatch(value, @"^[a-zA-Z0-9 ]+$"))
			{
				throw new ArgumentException(errorMessage);
			}
		}

		static public void ValidateObject(object @object)
		{
			ArgumentNullException.ThrowIfNull(@object);
		}

		static public object SetImagePath(string? path)
		{
			if (path == null || path == "")

				return DBNull.Value;

			return path;
		}

		static public int IntToStr(string? strValue)
		{
			if (int.TryParse(strValue, out int intValue))

				return intValue;

			return -1;
		}

		static public string FormatDate(DateTime date)
		{
			return $"{date.Year}-{date.Month:D2}-{date.Day:D2} ";
		}
	}
}
