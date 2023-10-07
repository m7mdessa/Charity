using Charity.Core.Data;
using Charity.Core.DTO;

namespace Charity.Core.Repository
{
	public interface IAuthRepository
	{
	  public void Register(Register register);
      public Login Login(Login login);
	  public void Forgotpassword(Forgotpassword email);
	  public void Resetpassword(Resetpassword reset);


	}
}
