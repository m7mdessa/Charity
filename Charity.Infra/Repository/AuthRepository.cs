using Charity.Core.Common;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using Microsoft.Win32;
using System.Data;

namespace Charity.Infra.Repository
{
	public class AuthRepository : IAuthRepository
	{
		private readonly IDbContext DbContext;
		private readonly IEmailService emailService;

		public AuthRepository(IDbContext dBContext, IEmailService emailService)
		{
			DbContext = dBContext;
			this.emailService = emailService;

		}

		public void Forgotpassword(Forgotpassword email)
		{

			email.verificationCode = GenerateVerificationCode();
			email.expirationTime = DateTime.Now.AddMinutes(3);

			var p = new DynamicParameters();
			p.Add("u_email", email.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("v_verification_code",  email.verificationCode, DbType.String, ParameterDirection.Input);
			p.Add("v_expiration_time", email.expirationTime, DbType.DateTime, ParameterDirection.Input);

			DbContext.Connection.Execute("Auth_Package.Forgotpassword", p, commandType: CommandType.StoredProcedure);
			var resetLink = $"http://localhost:4200/auth/ResetPassword";

			var emailSubject = "Password Reset";
			var emailBody = $@"<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333;
        }}

        .header {{
            font-size: 24px;
            font-weight: bold;
        }}

        .details {{
            font-size: 18px;
        }}

        .link {{
            font-size: 18px;
            color: #007BFF;
            text-decoration: none;
        }}

        .link:hover {{
            text-decoration: underline;
        }}

        .footer {{
            font-size: 14px;
            color: #999;
        }}
    </style>
</head>
<body>
    <div class='details'>
        <p class=""header"">Password Reset Request</p>
        <p>You have requested to reset your password. Please use the verification code and reset link below to reset your password:</p>
        <p class=""details"">Verification Code: <strong>{email.verificationCode}</strong></p>
        <p class=""details"">Reset Link: <a href='{resetLink}'>{resetLink}</a></p>
        <p>If you did not request this password reset, please ignore this email.</p>
        <p class=""footer"">Thank you!</p>
        <p class=""footer"">The verification code will expire in: {GetTimeRemaining(email.expirationTime)}</p>
    </div>
</body>
</html>
";

			_ = emailService.SendEmailAsync(email.Email, emailSubject, emailBody);
		}

		private string GetTimeRemaining(DateTime? expirationTime)
		{
				TimeSpan timeRemaining = expirationTime.Value - DateTime.Now;
				int minutesRemaining = (int)timeRemaining.TotalMinutes;
				return $"{minutesRemaining} minute{(minutesRemaining != 1 ? "s" : "")}";
		
		}


		private string GenerateVerificationCode()
		{

			return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6).ToUpper();
		}

		public void Resetpassword(Resetpassword reset)
		{
			var p = new DynamicParameters();
			p.Add("p_verification_code", reset.VerificationCode, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("p_new_password", reset.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
			
			DbContext.Connection.Execute("Auth_Package.ResetPassword", p, commandType: CommandType.StoredProcedure);
		}
		public Login Login(Login login)
        {
            var p = new DynamicParameters();
            p.Add("Uname", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result =DbContext.Connection.Query<Login>("Auth_Package.UserLogin", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }
		public string GetUserEmail(int Userid)
		{
			var p = new DynamicParameters();
			p.Add("u_id", Userid, DbType.Int32, ParameterDirection.Input);

			var result = DbContext.Connection.Query<string>("User_Package.GetUserEmail", p, commandType: CommandType.StoredProcedure).SingleOrDefault();

			return !string.IsNullOrEmpty(result) ? result : "Email not found";
		}
        public void Register(Register register)
		{
			var p = new DynamicParameters();
			p.Add("u_name", register.Username, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("u_email", register.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("pass", register.Password, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Auth_Package.Register", p, commandType: CommandType.StoredProcedure);
		}

		
	}
}
