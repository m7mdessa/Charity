using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;

namespace Charity.Infra.Service
{

	public class IssueService : IIssueService
	{
		private readonly IIssueRepository issueRepository;
		public IssueService(IIssueRepository issueRepository)
		{
			this.issueRepository = issueRepository;
		}
		public List<Issues> GetAllIssue()
		{
			return issueRepository.GetAllIssue();
		}
		public void CreateIssue(CharityIssue issue)
		{
			issueRepository.CreateIssue(issue);
		}
		public void DeleteIssue(int id)
		{
			issueRepository.DeleteIssue(id);
		}
		public void UpdateIssue(CharityIssue issue)
		{
			issueRepository.UpdateIssue(issue);
		}
		public CharityIssue GetIssueById(int id)
		{
			return issueRepository.GetIssueById(id);
		}
        public List<Issues> GetIssueByUserId(int user_id)
        {
            return issueRepository.GetIssueByUserId(user_id);
        }
      
	}

}
