using GS_Business;
using GS_DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GS_APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{

		[HttpGet("category/{categoryId:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<List<ProductDTO>> GetAllProducts(int categoryId)
		{
			try
			{
				if (!Category.IsExists(categoryId))
					return NotFound($"category with the Id {categoryId} Not found!");

				return Ok(Product.GetAllProducts(categoryId));
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpGet("product/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult GetProductById(int id)
		{
			try
			{
				ProductDTO? product = Product.GetProductById(id);

				if (product == null)
					return NotFound($"Product with id {id} not found.");

				return Ok(product);

			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return StatusCode(500, ex.Message);
			}

		}

		[HttpGet("barcode={barcode}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult GetProductBybarcode(string barcode)
		{
			try
			{
				ProductDTO? product = Product.GetProductByBarcod(barcode);

				if (product == null)
					return NotFound($"Product with barcode {barcode} not found.");

				return Ok(product);

			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return StatusCode(500, ex.Message);
			}

		}

		[HttpGet("name={name}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult GetProductByName(string name)
		{
			try
			{
				ProductDTO? product = Product.GetProductByName(name);

				if (product == null)
					return NotFound($"Product {name} not found.");

				return Ok(product);

			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return StatusCode(500, ex.Message);
			}

		}


		[HttpPost("add-new")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult AddProduct(NewProductDTO productDTO)
		{
			try
			{
				int newId = Product.AddProduct(productDTO.ConvertToProductDTO());

				if(newId > 0)
					return Ok(newId);

				return  StatusCode(500, "an error occurred!");
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpPut("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult UpdateProduct(UpdatedProductDTO productDTO)
		{
			try
			{
				int affectedRows = Product.UpdateProduct(productDTO.ConvertToProductDTO());

				if (affectedRows > 0)
					return Ok("Product updated successfully");

				return StatusCode(500, "an error occurred!");
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}


		[HttpGet("deleted")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult GetDeletedProducts()
		{
			try
			{
				List<ProductDTO> deletedProducts = Product.GetDeletedProducts();

				if (deletedProducts.Count == 0)
					return NotFound("No deleted products found.");

				return Ok(deletedProducts);

			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}


		[HttpDelete("delete/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult DeleteProduct(int id)
		{
			try
			{
				int affectedRows = Product.DeleteProduct(id);

				if (affectedRows == 0)
					return NotFound("Product not found or already deleted.");

				return Ok("Product deleted successfully.");
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}


		[HttpPut("restore/{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult RestoreProduct(int id)
		{
			try
			{
				int affectedRows = Product.RestoreProduct(id);

				if (affectedRows > 0)
					return Ok("Product restored successfully.");

				return NotFound("Product not found or already active.");
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

	
		
	}
}
