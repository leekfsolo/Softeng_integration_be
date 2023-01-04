using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softeng_integration_be.Models;
using Softeng_integration_be.Provider;

namespace uwc_2._0.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UsersProvider usersProvider = new();

		[HttpGet]
		public ActionResult GetAllUsers()
		{
			var data = usersProvider.GetAll();

			if (data == null)
			{
				return NotFound();
			}

			return Ok(new { success = true, data = data.Result });
		}

		[HttpPost("authenticate")]
		public ActionResult Authenticate([FromBody] User userLogin)
		{
			var user = usersProvider.Authenticate(userLogin);

			if (user is null)
			{
				return Ok(new { isUserExisted = false });
			}

			return Ok(new { isUserExisted = true, email = user.Email });
		}
	}
}
