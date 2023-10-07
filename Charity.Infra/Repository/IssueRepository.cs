using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using System.Data;

namespace Charity.Infra.Repository
{
	public class IssueRepository : IIssueRepository
	{
		private readonly IDbContext DbContext;
		public IssueRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}
		public void CreateIssue(CharityIssue issue)
		{
			var p = new DynamicParameters();
			p.Add("i_description", issue.Issuedescription, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("u_id", issue.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Issues_Package.CreateIssue", p, commandType: CommandType.StoredProcedure);
		}

		public void DeleteIssue(int id)
		{
			var p = new DynamicParameters();
			p.Add("i_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Issues_Package.DeleteIssue", p, commandType: CommandType.StoredProcedure);
		}

		public List<Issues> GetAllIssue()
		{
			IEnumerable<Issues> result = DbContext.Connection.Query<Issues>("Issues_Package.GetAllIssue", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public CharityIssue GetIssueById(int id)
		{
			var p = new DynamicParameters();
			p.Add("i_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<CharityIssue> result = DbContext.Connection.Query<CharityIssue>("Issues_Package.GetIssueById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}
        public List<Issues> GetIssueByUserId(int user_id)
        {
            var p = new DynamicParameters();
            p.Add("u_id", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Issues> result = DbContext.Connection.Query<Issues>("Issues_Package.GetIssueByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public void UpdateIssue(CharityIssue issue)
		{
			var p = new DynamicParameters();
			p.Add("i_id", issue.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("i_status", issue.Status, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("i_response", issue.Response, dbType: DbType.String, direction: ParameterDirection.Input);

			DbContext.Connection.Execute("Issues_Package.UpdateIssue", p, commandType: CommandType.StoredProcedure);
		}
		
	}
}
