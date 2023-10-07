using Charity.Core.Data;
using Charity.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : Controller
	{
		private readonly IContactService ContactService;
		public ContactController(IContactService ContactService)
		{
			this.ContactService = ContactService;

		}

		[HttpGet]
		public List<CharityContact> GetAllContact()
		{
			return ContactService.GetAllContact();
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteContact(int id)
		{
			ContactService.DeleteContact(id);
		}

		[HttpPost]
		public void CreateContact(CharityContact contact)
		{

			ContactService.CreateContact(contact);
		}
	}
}
