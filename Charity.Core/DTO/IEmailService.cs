using MimeKit;
using MailKit.Net.Smtp;

public class IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Admin", "your-email@example.com"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;
        message.Body = new TextPart("html")
        {
            Text = body
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("ysym1037@gmail.com", "yeneimvtaqibotpx");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }



	public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachmentBytes, string attachmentFileName)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Admin", "your-email@example.com"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = body;

        // Add attachment
        var attachment = new MimePart("application", "pdf")
        {
            Content = new MimeContent(new MemoryStream(attachmentBytes)),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            FileName = attachmentFileName
        };

        bodyBuilder.Attachments.Add(attachment);

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("ysym1037@gmail.com", "yeneimvtaqibotpx");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }

}
