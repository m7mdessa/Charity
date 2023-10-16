using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using System.Data;

namespace Charity.Infra.Repository
{
	public class CharityRepository : ICharityRepository
	{

		private readonly IDbContext DbContext;
		public CharityRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}

		public void CreateCharity(Charitys charity)
		{
			var p = new DynamicParameters();
			p.Add("c_name", charity.Charityname, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("c_latitude", charity.Latitude, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("c_longitude", charity.Longitude, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("c_mission", charity.Mission, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("c_address", charity.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_id", charity.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("c_image", charity.Image, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("c_g_price", charity.Goalprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
			p.Add("c_m_price", charity.Minprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Charity_Package.CreateCharity", p, commandType: CommandType.StoredProcedure);
		}
		
		public void DeleteCharity(int id)
		{
			var p = new DynamicParameters();
			p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		    DbContext.Connection.Execute("Charity_Package.DeleteCharity", p, commandType: CommandType.StoredProcedure);
		}

	

		public List<Charities> GetAllCharities()
		{
			IEnumerable<Charities> result = DbContext.Connection.Query<Charities>("Charity_Package.GetAllCharities", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}
        public List<Charities> GetCharityByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("u_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Charities> result = DbContext.Connection.Query<Charities>("Charity_Package.GetCharityByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public Charitys GetCharityById(int id)
		{
			var p = new DynamicParameters();
			p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<Charitys> result = DbContext.Connection.Query<Charitys>("Charity_Package.GetCharityById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

	

		public void UpdateCharity(Charities charity)
		{
			var p = new DynamicParameters();
			p.Add("c_id", charity.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("c_status", charity.Status, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("c_price", charity.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);

			DbContext.Connection.Execute("Charity_Package.UpdateCharity", p, commandType: CommandType.StoredProcedure);
		}
	}

}


