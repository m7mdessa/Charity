using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;
using Charity.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : Controller
	{
		private readonly IAuthService authService;

		public AuthController(IAuthService authService)
		{
			this.authService = authService;

		}


		[HttpPost]
		[Route("Register")]
		public void Register([FromBody] Register  register)
		{

			authService.Register(register);
		}

        [HttpPost]
		[Route("Login")]

		public IActionResult Login([FromBody] Login login)
		{
            var token = authService.Login(login );
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
		[HttpPost]
		[Route("Forgotpassword")]
		public void Forgotpassword(Forgotpassword email)
		{
			authService.Forgotpassword(email);
	

		}

		[HttpPost]
		[Route("Resetpassword")]
		public void Resetpassword(Resetpassword reset)
		{
			authService.Resetpassword(reset);
		}

	}
}
