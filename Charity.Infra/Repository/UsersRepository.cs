using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Infra.Repository
{
	public class UsersRepository : IUsersRepository
	{
		private readonly IDbContext DbContext;
		public UsersRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}
		public void CreateUser(CharityUser user)
		{
			var p = new DynamicParameters();
			p.Add("u_name", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("u_email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("pass", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Users_Package.CreateUser", p, commandType: CommandType.StoredProcedure);
		}

		public void DeleteUser(int id)
		{
			var p = new DynamicParameters();
			p.Add("u_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Users_Package.DeleteUser", p, commandType: CommandType.StoredProcedure);
		}

		public List<CharityUser> GetAllUsers()
		{
			IEnumerable<CharityUser> result = DbContext.Connection.Query<CharityUser>("Users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public CharityUser GetUserById(int id)
		{
			var p = new DynamicParameters();
			p.Add("u_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<CharityUser> result = DbContext.Connection.Query<CharityUser>("Users_Package.GetUserById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
        }

		public void UpdateUser(CharityUser user)
		{
			var p = new DynamicParameters();
			p.Add("u_id", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("u_name", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);

			DbContext.Connection.Execute("Users_Package.UpdateUser", p, commandType: CommandType.StoredProcedure);
		}
	}
}
