using Microsoft.AspNetCore.Mvc;
using static GS_DTOs.UserDTOs;

namespace GS_APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<List<UserDTO>> GetAllUsers()
		{
			try
			{
				List<UserDTO> users = GS_Business.User.GetAll();

				if (users.Count == 0)
				{
					return NotFound("No users found.");
				}

				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<UserDTO> GetUserById(int id)
		{
			try
			{
				UserDTO? user = GS_Business.User.Find(id);
				if (user == null)
				{
					return NotFound($"User with ID {id} not found.");
				}
				return Ok(user);
			}
			catch(ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

		}

		[HttpPost("/add-new")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult CreateUser(CreateUserDTO DTO)
		{
			try
			{
				int newUserId = GS_Business.User.AddNew(DTO);

				if (newUserId <= 0)
					return BadRequest("Failed to create user.");

				return CreatedAtAction(nameof(GetUserById), new { id = newUserId }, new { id = newUserId });
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


		[HttpPut("/update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult UpdateUser(UpdateUserDTO DTO)
		{
			try
			{
				if (GS_Business.User.Find(DTO.Id) == null)

					return NotFound($"User with ID {DTO.Id} not found.");

				int affectedRows = GS_Business.User.Update(DTO);

				if (affectedRows > 0)
					return Ok("User updated successfully");

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

		[HttpPut("activation/{userId:int}/{status:bool}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult Activation(int userId, bool status)
		{
			try
			{
				if (GS_Business.User.Find(userId) == null)
					return NotFound($"User with ID {userId} not found.");

				int affectedRows = GS_Business.User.Activation(userId, status);

				if (affectedRows > 0)
					return Ok($"User {(status ? "activated" : "deactivated")} successfully.");

				return StatusCode(500, "Failed to update user status.");
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
