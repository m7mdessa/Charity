using Charity.Core.Data;
using Charity.Core.DTO;

namespace Charity.Core.Service
{
	public interface IAuthService
	{
		public void Register(Register register);

		public string Login(Login login);
		public void Forgotpassword(Forgotpassword email);
		public void Resetpassword(Resetpassword reset);



	}
}
