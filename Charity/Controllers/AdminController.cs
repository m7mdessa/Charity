using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;
using Charity.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Charity.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : Controller
	{
		private readonly IAdminService adminService;

		public AdminController(IAdminService adminService)
		{
			this.adminService = adminService;

		}

	
		[HttpPut]
		[Route("UpdateAdmin")]
		[Authorize(Roles = "admin")]
		public void UpdateAdmin(CharityUser admin)
		{
			adminService.UpdateAdmin(admin);
		
		}

        [HttpPut]
        [Route("AcceptCharity")]
        public void AcceptCharity(Charities charity)
        {
            adminService.AcceptCharity(charity);
        }

        [HttpGet]
		[Route("NumberOfUsers")]
		public int GetNumberOfUsers()
		{
			return	adminService.GetNumberOfUsers();
		}

		[HttpGet]
		[Route("NumberOfCharitis")]
		public int GetNumberOfCharities()
		{
			return adminService.GetNumberOfCharities();
		}

		[HttpGet]
		[Route("NumberOffNotifications")]
		public int GetNumberOfNotifications()
		{
			return adminService.GetNumberOfNotifications();
		}

		[HttpGet]
        [Route("MaxCharityCategory")]
        public List<CategoryWithMaxCharities> MaxCharityCategory()
        {
            return adminService.MaxCharityCategory();
        }
		[HttpPost]
		[Route("SerchBetweenDates/{dateFrom},{dateTo}")]
        public List<Charitys> SerchBetweenDates(DateTime DateFrom, DateTime DateTo)
        {
            return adminService.SerchBetweenDates(DateFrom, DateTo);
        }

        [HttpGet]
		[Route("Reports")]
		public List<Reports> Reports()
		{

			return adminService.Reports();


		}

		[HttpGet]
		[Route("GetAllNotifications")]
		public List<CharityNotification> GetAllNotifications()
		{
			return adminService.GetAllNotifications();
		}
		[HttpGet]
		[Route("GetAllDonations")]
		public List<Donations> GetAllDonations()
		{
			return adminService.GetAllDonations();

		}
	
		[HttpGet]
		[Route("Benefits")]
		public List<Benefits> benefits()
		{
			return adminService.benefits();
		}
		[HttpPost]
		[Route("ReportsInterval")]

		public List<Reports> ReportsInterval(DateTime StartDate, DateTime EndDate)
		{
			return adminService.ReportsInterval(StartDate, EndDate);
		}
	}
}

