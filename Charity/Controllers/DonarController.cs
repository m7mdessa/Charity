using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class DonarController : Controller
	{
		private readonly IDonarService donarService;
		private readonly IEmailService emailService;
        private readonly IUsersService usersService;
        private readonly ICharityService charityService;


        public DonarController(IDonarService userService, IEmailService emailService , IUsersService usersService, ICharityService charityService)
		{
			this.donarService = userService;
			this.emailService = emailService;
            this.usersService = usersService;
            this.charityService = charityService;


        }

        [HttpPut]
		[Route("UpdateUser")]

		public void UpdateUser(CharityUser user)
		{
            donarService.UpdateUser(user);

		}
		[HttpGet]
		[Route("GetUserById/{id}")]
		public List<CharityUser> GetUserById(int id)
		{
		return donarService.GetUserById(id);
		}


		[HttpPost]
		[Route("PayForCharity/{userId}/{charityId}")]

		public void PayForCharity(int userId, int charityId, Payment payment )
		{


            donarService.PayForCharity(userId, charityId, payment );

			CharityUser user = usersService.GetUserById(userId);
			Charitys charity = charityService.GetCharityById(charityId);



            byte[] invoicePdfBytes = GenerateInvoicePdf(charity);
			var emailSubject = "Charity Paid";
			var attachmentName = "invoice.pdf";
			var attachmentData = invoicePdfBytes;

			var emailBody = $@"
<html>
<head>
      <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f7f7f7;
            padding: 20px;
        }}
        .container {{
            max-width: 600px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            font-size: 24px;
            font-weight: bold;
            color: #333;
            margin-bottom: 20px;
            text-align: center;
        }}
        .details {{
            font-size: 16px;
            color: #666;
            line-height: 1.5;
        }}
        .button {{
            display: inline-block;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: #fff;
            text-decoration: none;
            border-radius: 4px;
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>Charity Paid</div>
        <div class='details'>
            <p>Your Charity has beeing Paid.</p>
            <p>Please find the attached invoice below:</p>
        </div>
    </div>
</body>
</html>";

			_ = emailService.SendEmailWithAttachmentAsync(user.Email, emailSubject, emailBody, attachmentData, attachmentName);




		}

		private byte[] GenerateInvoicePdf(Charitys charity)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Document document = new Document();
				PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

				document.Open();
				document.AddTitle("Invoice");
				document.AddAuthor("Charitys");

				iTextSharp.text.Font headerFont = new Font(Font.FontFamily.HELVETICA, 24, Font.BOLD);
				Font cellFont = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.DARK_GRAY);
				Font headerCellFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.WHITE);

				Paragraph header = new Paragraph("Invoice", headerFont);
				header.Alignment = Element.ALIGN_CENTER;
				document.Add(header);


					document.Add(new Paragraph() { SpacingAfter = 20 });

					PdfPTable table = new PdfPTable(5);
					table.WidthPercentage = 100;

					float[] columnWidths = { 3f, 1.5f, 1.5f, 2f, 1.5f };
					table.SetWidths(columnWidths);

					table.AddCell(CreateStyledCell("Charity", headerCellFont, BaseColor.DARK_GRAY));
					table.AddCell(CreateStyledCell("Location", headerCellFont, BaseColor.DARK_GRAY));
					table.AddCell(CreateStyledCell("Goals", headerCellFont, BaseColor.DARK_GRAY));
					table.AddCell(CreateStyledCell("Price", headerCellFont, BaseColor.DARK_GRAY));
					table.AddCell(CreateStyledCell("Status", headerCellFont, BaseColor.DARK_GRAY));

					table.AddCell(CreateStyledCell(charity.Charityname, cellFont));
					//table.AddCell(CreateStyledCell(charity.Mission.ToString(), cellFont));
					table.AddCell(CreateStyledCell(charity.Price.ToString(), cellFont));
					table.AddCell(CreateStyledCell(charity.Status, cellFont));

					document.Add(table);

					document.NewPage(); 
				

				document.Close();

				return memoryStream.ToArray();
			}
		}


		private PdfPCell CreateStyledCell(string text, Font font, BaseColor backgroundColor = null)
		{
			PdfPCell cell = new PdfPCell(new Phrase(text, font));

			cell.PaddingTop = 8;
			cell.PaddingBottom = 8;

			if (backgroundColor != null)
			{
				cell.BackgroundColor = backgroundColor;
			}

			return cell;
		}

		private Paragraph CreateStyledParagraph(string text, Font font)
		{
			Paragraph paragraph = new Paragraph(text, font);
			return paragraph;
		}

		[HttpPost]
		[Route("DonateForCharity/{userId}/{charityId}/{totalPrice}")]
		public void DonateForCharity(int userId, int charityId, Decimal totalPrice, Payment payment)
		{

            donarService.DonateForCharity(userId, charityId, totalPrice, payment);
		}

		[HttpGet]
		[Route("GetDonationByUserId/{userId}")]
		public List<Donations> GetDonationByUserId(int userId)
		{
			return donarService.GetDonationByUserId(userId);
		}

        [HttpGet]
        [Route("GetUserNotifications/{userId}")]
        public List<CharityNotification> GetUserNotifications(CharityNotification notification)
        {
            return donarService.GetUserNotifications(notification);
        }


        [HttpGet]
        [Route("GetNumberOfUserNotifications/{userId}")]
        public int GetNumberOfUserNotifications(CharityNotification notification)
        {
            return donarService.GetNumberOfUserNotifications(notification);
        }
        [Route("uploadImage")]
		[HttpPost]
		public CharityUser UploadImage()
		{
			var file = Request.Form.Files[0];
			var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
            CharityUser item = new CharityUser();
			item.Image = fileName;
			return item;
		}
	}
}
