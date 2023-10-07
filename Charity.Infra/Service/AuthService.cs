using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Charity.Infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public void Forgotpassword(Forgotpassword email)
		{
			authRepository.Forgotpassword(email);
		}
		public void Resetpassword(Resetpassword reset)
		{
			authRepository.Resetpassword(reset);
		}
		public string Login(Login login)
		{
			var result = authRepository.Login(login);

			if (result == null)
			{
				return null;
			}
			else
			{
				// Generate a 256-bit key for HMAC SHA-256
				byte[] keyBytes = new byte[32]; // 256 bits
				using (var rng = new RNGCryptoServiceProvider())
				{
					rng.GetBytes(keyBytes);
				}

				var secretKey = new SymmetricSecurityKey(keyBytes);
				var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
				var claims = new List<Claim>
		{
			new Claim("Name", result.Username),
			new Claim("Role", result.Roleid.ToString()),
			new Claim("UserId", result.id.ToString())
		};
				var tokenOptions = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddHours(24),
					signingCredentials: signinCredentials
				);

				var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
				return tokenString;
			}
		}

		public void Register(Register register)
		{
			authRepository.Register(register);
		}

		
	}
}

