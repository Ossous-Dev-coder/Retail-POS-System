
using GSData;
using GSData.DTOs;
using Microsoft.IdentityModel.Tokens;
using GSData.Data;






try
{

	//ProductDTO? product = ProductData.GetProductByName(null);

	//Console.WriteLine("============================");
	//Console.WriteLine(product?.Id);
	//Console.WriteLine(product?.BarCode);
	//Console.WriteLine(product?.Name);
	//Console.WriteLine(product?.CategoryId);
	//Console.WriteLine(product?.Description);
	//Console.WriteLine(product?.CreatedAt);
	//Console.WriteLine(product?.Quantity);
	//Console.WriteLine(product?.UnitPrice);
	//Console.WriteLine(product?.PricingTypeId);
	//Console.WriteLine("============================");

	//	foreach (var product in products)
	//	{
	//		Console.WriteLine("============================");
	//		Console.WriteLine(product.Id);
	//		Console.WriteLine(product.BarCode);
	//		Console.WriteLine(product.Name);
	//		Console.WriteLine(product.Description);
	//		Console.WriteLine(product.UnitPrice);
	//		Console.WriteLine("============================");
	//	}

	//Console.WriteLine(GSUtility.FormatDate(DateTime.Today.Date));

	List<MovementDTO> movements = StockData.GetMovements(new DateTime(2026, 6, 9), new DateTime(2026, 6, 9), 5, 5);

	foreach (MovementDTO mv in movements)
	{
		Console.WriteLine(mv.Id);
		Console.WriteLine(mv.CreatedAt);
		Console.WriteLine(mv.ProductId);
		Console.WriteLine(mv.MovementTypeId);
		Console.WriteLine(mv.Quantity);
	}
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}




