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



		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult CreateUser(CreateUserDTO DTO)
		{
			if (DTO == null)
				return BadRequest();

			int userId = GS_Business.User.Add(DTO);

			if (userId <= 0)
				return BadRequest("Failed to create user.");

			return CreatedAtAction("GetUserById", new { id = userId }, new { id = userId });
		}


	}
}
