using Charity.Core.Data;
using Charity.Core.DTO;

namespace Charity.Core.Repository
{
	public interface IIssueRepository
	{
		List<Issues> GetAllIssue();
		void CreateIssue(CharityIssue issue);
		void DeleteIssue(int id);
		public void UpdateIssue(CharityIssue issue);
		CharityIssue GetIssueById(int id);
        public List<Issues> GetIssueByUserId(int user_id);

	}
}
