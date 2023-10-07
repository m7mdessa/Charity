using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Charity.Infra.Repository
{
	public class DonarRepository : IDonarRepository
	{
		private readonly IDbContext DbContext;
		public DonarRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}
		public void UpdateUser(CharityUser user)
		{
			var p = new DynamicParameters();
			p.Add("u_id", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("pass", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);

			DbContext.Connection.Execute("Donar_Package.UpdateUser", p, commandType: CommandType.StoredProcedure);
		}
	
		public void PayForCharity(int Userid, int Charityid, Payment payment )
		{
			var p = new DynamicParameters();

			p.Add("u_id",Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("c_id", Charityid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_cardholdername", payment.Cardholdernumber, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_cardnumber", payment.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_expirationdate", payment.Expirationdate, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_cvv", payment.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Donar_Package.PayForCharity", p, commandType: CommandType.StoredProcedure);  

		}
		public void DonateForCharity(int userId, int charityId, Payment payment)
		{
			var p = new DynamicParameters();
			p.Add("u_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("c_id", charityId, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("p_cardholdername", payment.Cardholdernumber, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_cardnumber", payment.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_expirationdate", payment.Expirationdate, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_cvv", payment.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Donar_Package.DonateForCharity", p, commandType: CommandType.StoredProcedure);

		}

		public List<Donations> GetDonationByUserId(int userId)
		{
			var p = new DynamicParameters();
			p.Add("u_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<Donations> result = DbContext.Connection.Query<Donations>("Donar_Package.GetDonationByUserId", p, commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

        public List<CharityNotification> GetUserNotifications(CharityNotification notification)
        {
            var p = new DynamicParameters();
            p.Add("u_id", notification.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<CharityNotification> result = DbContext.Connection.Query<CharityNotification>("Donar_Package.GetUserNotifications", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int GetNumberOfUserNotifications(CharityNotification notification)
        {
            var p = new DynamicParameters();
            p.Add("u_id", notification.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteScalar<int>("Donar_Package.GetNumberOfUserNotifications", commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
