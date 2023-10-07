using Charity.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.Repository
{
	public interface IUsersRepository
	{
		List<CharityUser> GetAllUsers();
		public void CreateUser(CharityUser user);

		public void DeleteUser(int id);
		public CharityUser GetUserById(int id);
		public void UpdateUser(CharityUser user);
	}
}
