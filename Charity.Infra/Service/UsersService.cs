using Charity.Core.Data;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Infra.Service
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository usersRepository;
		public UsersService(IUsersRepository usersRepository)
		{
			this.usersRepository = usersRepository;
		}
		public void CreateUser(CharityUser user)
		{
			usersRepository.CreateUser(user);
		}

		public void DeleteUser(int id)
		{
			usersRepository.DeleteUser(id);
		}

		public List<CharityUser> GetAllUsers()
		{
		return	usersRepository.GetAllUsers();
		}

		public CharityUser GetUserById(int id)
		{
            return usersRepository.GetUserById(id);
		}

		public void UpdateUser(CharityUser user)
		{
			usersRepository.UpdateUser(user);
		}
	}
}
