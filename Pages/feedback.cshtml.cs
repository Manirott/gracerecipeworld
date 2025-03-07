using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net;
using System.Net.Mail;

namespace reciepe.Pages
{
    public class FeedbackModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public string ResultMessage { get; set; }

        public void OnGet()
        {
            ResultMessage = string.Empty;
        }

        public IActionResult OnPost()
        {
            try
            {
                var senderEmail = "manikandandhinakar@gmail.com"; // Your email address
                var senderPassword = "pwgd jpyz btji fijh"; // App Password (Gmail/Outlook/Yahoo)
                var receiverEmail = "nafiyams22@gmail.com"; // Where feedback is received

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = "New Feedback from " + Name,
                    Body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}",
                    IsBodyHtml = false
                };

                mail.To.Add(receiverEmail);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587) // Gmail SMTP
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
                ResultMessage = "✅ Feedback sent successfully!";
            }
            catch (Exception ex)
            {
                ResultMessage = "❌ Error: " + ex.Message;
            }

            return Page();
        }
    }
}
