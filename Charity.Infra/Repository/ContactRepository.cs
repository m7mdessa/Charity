using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Repository;
using Dapper;
using System.Data;

namespace Charity.Infra.Repository
{
	public class ContactRepository : IContactRepository
	{
		
			private readonly IDbContext DbContext;
			public ContactRepository(IDbContext dBContext)
			{
				DbContext = dBContext;
			}
		    public List<CharityContact> GetAllContact()
		    {

			     IEnumerable<CharityContact> result = DbContext.Connection.Query<CharityContact>("Contact_Package.GetAllContact", commandType: CommandType.StoredProcedure);
			     return result.ToList();

		    }

		    public void DeleteContact(int id)
		    {

			     var p = new DynamicParameters();
			     p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		         DbContext.Connection.Execute("Contact_Package.DeleteContact", p, commandType: CommandType.StoredProcedure);

		    }
	     	
		    public void CreateContact(CharityContact contact)
		    {
		         var p = new DynamicParameters();
			     p.Add("c_name", contact.Contactname, dbType: DbType.String, direction: ParameterDirection.Input);
			     p.Add("c_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
		       	 p.Add("c_phone", contact.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
			     p.Add("c_subject", contact.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
			     p.Add("c_message", contact.Message, dbType: DbType.String, direction: ParameterDirection.Input);
			     DbContext.Connection.Execute("Contact_Package.CreateContact", p, commandType: CommandType.StoredProcedure);

		    }

	}
}
