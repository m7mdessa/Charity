using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Service;
using Charity.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class IssueController : Controller
	{
		private readonly IIssueService issueService;
		private readonly IEmailService emailService;

		public IssueController(IIssueService issueService, IEmailService emailService)
		{
			this.issueService = issueService;
			this.emailService = emailService;

		}

		[HttpGet]
		public List<Issues> GetAllIssue()
		{
			return issueService.GetAllIssue();
		}

		[HttpPost]

		public void CreateIssue(CharityIssue Issue)
		{
			issueService.CreateIssue(Issue);
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteIssue(int id)
		{
			issueService.DeleteIssue(id);
		}

		[HttpGet]
		[Route("GetIssueById/{id}")]
		public CharityIssue GetIssueById(int id)
		{
			return issueService.GetIssueById(id);
		}
        [HttpGet]
        [Route("GetIssueByUserId/{user_id}")]
        public List<Issues> GetIssueByUserId(int user_id)
        {
            return issueService.GetIssueByUserId(user_id);
        }

        [HttpPut]
		[Route("UpdateIssue")]

		public void UpdateIssue(CharityIssue Issue)
		{
			issueService.UpdateIssue(Issue);
		
		}


	}

}
