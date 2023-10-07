using Charity.Core.Data;
using Charity.Core.Service;
using Charity.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : Controller
	{
		private readonly IUsersService usersService;

		public UsersController(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		[HttpPost]
		[Route("addUser")]
		public void CreateUser(CharityUser user)
		{
			usersService.CreateUser(user);
		}
		[HttpDelete]
		[Route("Delete/{id}")]

		public void DeleteUser(int id)
		{
			usersService.DeleteUser(id);
		}
		[HttpGet]

		public List<CharityUser> GetAllUsers()
		{
			return usersService.GetAllUsers();
		}
		[HttpGet]
		[Route("GetUserById/{id}")]
		public CharityUser GetUserById(int id)
		{
		return	 usersService.GetUserById(id);
		}

		[HttpPut]
		public void UpdateUser(CharityUser user)
		{
			usersService.UpdateUser(user);
		}
	}
}
