﻿using Charity.Core.Data;
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
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
                var signinCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                   {
    	          new  Claim ("Name", result.Username),
                	new Claim("Role", result.Roleid.ToString()),
                	new Claim("UserId", result.id.ToString())
                   };
                var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires:DateTime.Now.AddHours(24),
                signingCredentials: signinCredentials
                 );
                var tokenString = new
               JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
        }

        public void Register(Register register)
		{
			authRepository.Register(register);
		}

       
    }
}

