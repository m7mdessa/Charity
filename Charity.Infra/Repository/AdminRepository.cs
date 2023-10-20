using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Charity.Infra.Repository
{
	public class AdminRepository : IAdminRepository
	{

		private readonly IDbContext DbContext;
		public AdminRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}

		public void UpdateAdmin(CharityUser admin)
		{
			var p = new DynamicParameters();
			p.Add("a_id", admin.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("pass", admin.Password, dbType: DbType.String, direction: ParameterDirection.Input);

			DbContext.Connection.Execute("Admin_Package.UpdateAdmin", p, commandType: CommandType.StoredProcedure);

		}
        public int GetNumberOfUsers()
        {
			var result = DbContext.Connection.ExecuteScalar<int>("Admin_Package.GetNumberOfUsers", commandType: CommandType.StoredProcedure);
			return result;
		}
		public int GetNumberOfCharities()
		{

			var result = DbContext.Connection.ExecuteScalar<int>("Admin_Package.GetNumberOfCharities", commandType: CommandType.StoredProcedure);
			return result;
		}
	
        public List<CategoryWithMaxCharities> MaxCharityCategory()
        {
            var result = DbContext.Connection.Query<CategoryWithMaxCharities>("Admin_Package.FindCategoryWithMaxCharities", commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

		public List<Charitys> SerchBetweenDates(DateTime DateFrom, DateTime DateTo)
		{
			var p = new DynamicParameters();
		
			p.Add("DateFrom", DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			p.Add("DateTo", DateTo, dbType:DbType.DateTime, direction: ParameterDirection.Input);
			var result = DbContext.Connection.Query<Charitys>("Admin_Package.SerchBetweenDates", p, commandType: CommandType.StoredProcedure);
			return result.ToList();

		}
		public List<Reports> Reports()
		{
			IEnumerable<Reports> result = DbContext.Connection.Query<Reports>("Admin_Package.Reports", commandType: CommandType.StoredProcedure);

			return result.ToList();
		}

		public List<Benefits> benefits()
		{

			IEnumerable<Benefits> result = DbContext.Connection.Query<Benefits>("Admin_Package.benefits", commandType: CommandType.StoredProcedure);
		
			return result.ToList();

		}

		public List<Reports> ReportsInterval( DateTime StartDate , DateTime EndDate)
		{
			var p = new DynamicParameters();

			p.Add("p_start_date", StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			p.Add("p_end_date", EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			IEnumerable<Reports> result = DbContext.Connection.Query<Reports>("Admin_Package.ReportsInterval", commandType: CommandType.StoredProcedure);

			return result.ToList();
		}

		public List<CharityNotification> GetAllNotifications()
		{
			IEnumerable<CharityNotification> result = DbContext.Connection.Query<CharityNotification>("Admin_Package.GetAllNotifications", commandType: CommandType.StoredProcedure);

			return result.ToList();
		}

		public int GetNumberOfNotifications()
		{

			var result = DbContext.Connection.ExecuteScalar<int>("Admin_Package.GetNumberOfNotifications", commandType: CommandType.StoredProcedure);
			return result;
		}

		public List<Donations> GetAllDonations()
		{
			IEnumerable<Donations> result = DbContext.Connection.Query<Donations>("Admin_Package.GetAllDonations", commandType: CommandType.StoredProcedure);

			return result.ToList();
		}

        public void AcceptCharity(Charities charity)
        {
            var p = new DynamicParameters();
            p.Add("c_id", charity.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("c_status", charity.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("c_price", charity.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Admin_Package.AcceptCharity", p, commandType: CommandType.StoredProcedure);
        }
    }
}
