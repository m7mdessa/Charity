using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Service;
using Charity.Infra.Repository;
using Charity.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharityController : Controller
	{
		private readonly ICharityService charityService;
		private readonly IEmailService emailService;

		public CharityController(ICharityService charityService , IEmailService emailService)
		{
			this.charityService = charityService;
			this.emailService = emailService;

		}

		[HttpGet]

		public List<Charities> GetAllCharities()
		{

			return charityService.GetAllCharities();
		}

		[HttpPost]
		public void CreateCharity(Charitys charity)
		{
			charityService.CreateCharity(charity);
		}

        [HttpGet]
        [Route("getCharityByUserId/{userId}")]
        public List<Charities> GetCharityByUserId(int userId)
        {

            return charityService.GetCharityByUserId(userId);
        }

        [HttpGet]
        [Route("GetCharityByCategory/{categoryId}")]
        public List<Charities> GetCharityByCategory(int categoryId)
        {
            return charityService.GetCharityByCategory(categoryId);
        }


        [HttpPut]
        [Route("UpdateCharity")]

        public void UpdateCharity(Charities charity)
		{
			charityService.UpdateCharity(charity);


			if (charity.Status == "Accepted")

			{
				var emailSubject = "Charity Accepted";
				var emailBody = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
            }}
            .header {{
                font-size: 20px;
                font-weight: bold;
                color: #333;
            }}
            .details {{
                font-size: 16px;
                color: #666;
            }}
        </style>
    </head>
    <body>
        <div class='details'>
            <p>Your charity is accepted</p>
            <p> Details:</p>
            <ul>
                <li>Charity Price: {charity?.Price}</li>
                <li>Date: {DateTime.Now}</li>
            </ul>
        </div>
    </body>
    </html>";


				_ = emailService.SendEmailAsync(charity?.email, emailSubject, emailBody);

			}
			else if (charity.Status == "Rejected")

			{

				_ = emailService.SendEmailAsync(charity.email, "Charity Rejected", "Sorry your charity has been rejected");

			}
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteCharity(int id)
		{
			charityService.DeleteCharity(id);
		}

		[HttpGet]
		[Route("getCharityById/{id}")]
		public Charitys GetCharityById(int id)
		{
			return charityService.GetCharityById(id);
		}

		[Route("uploadImage")]
		[HttpPost]
		public Charitys UploadImage()
		{
			var file = Request.Form.Files[0];
			var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			Charitys item = new Charitys();
			item.Image = fileName;
			return item;
		}

	}
}
