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
		public ActionResult<List<UserDTO>> GetAllUsers()
		{
			List<UserDTO> users = GS_Business.User.GetAll();

			if(users.Count == 0)
			{
				return NotFound("No users found.");
			}

			return Ok(users);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<UserDTO> GetUserById(int id)
		{
			UserDTO? user = GS_Business.User.Find(id);
			if (user == null)
			{
				return NotFound($"User with ID {id} not found.");
			}
			return Ok(user);
		}

		[HttpPost("/add-new")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult CreateUser(CreateUserDTO DTO)
		{
			if (DTO == null)
				return BadRequest();

			int userId = GS_Business.User.Add(DTO);

			if (userId <= 0)
				return BadRequest("Failed to create user.");

			return CreatedAtAction(nameof(GetUserById), new { id = userId }, new { id = userId });
		}


		[HttpPut("/update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult UpdateUser(UpdateUserDTO DTO)
		{
			try
			{
				if (DTO == null)
					return BadRequest();

				int affectedRows = GS_Business.User.Update(DTO);

				if (affectedRows <= 0)
					return BadRequest("Failed to update user.");

				return Ok("User updated successfully.");
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
