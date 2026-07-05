using GS_APIs.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static GS_DTOs.UserDTOs;

namespace GS_APIs.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			UserDTO? user = GS_Business.User.Find(request.Email);

			if (user == null)
				return Unauthorized("Invalid credentials");

			bool isValidPassword =
				BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);


			if (!isValidPassword)
				return Unauthorized("Invalid credentials");



			Claim [] claims = new[] 
			{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

                new Claim(ClaimTypes.Email, user.Email),

                new Claim(ClaimTypes.Role, user.RoleName)
			};


			// Step 4: Create the symmetric security key used to sign the JWT.
			// This key must match the key used in JWT validation middleware.
			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));


			// Step 5: Define the signing credentials.
			// This specifies the algorithm used to sign the token.
			SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


			// Step 6: Create the JWT token.
			// The token includes issuer, audience, claims, expiration, and signature.
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: "RetailPOS",
				audience: "RetailPOSUsers",
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds
			);


			// Step 7: Return the serialized JWT token to the client.
			// The client will send this token with future requests.
			return Ok(new
			{
				token = new JwtSecurityTokenHandler().WriteToken(token)
			});
		}
	}
}
