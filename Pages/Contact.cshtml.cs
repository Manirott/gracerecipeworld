using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace reciepe.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // This method handles GET requests (when the page is loaded)
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Configure email settings
                var fromAddress = new MailAddress("manikandandhinakar@gmail.com", "Nafi Kitchen"); // Replace with your email
                var toAddress = new MailAddress("nafiyams22@gmail.com", "Support");
                const string fromPassword = "pwgd jpyz btji fijh"; // Replace with your email password or app-specific password
                const string subject = "New Message from Recipe World Contact Form";

                // Create the email body
                string body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}";

                // Set up the SMTP client
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // Use Gmail's SMTP server
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                // Create the email message
                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(mailMessage);
                }

                // Show success message
                SuccessMessage = "Your message has been sent successfully!";
                ErrorMessage = null;
            }
            catch (Exception ex)
            {
                // Show error message
                ErrorMessage = "An error occurred while sending your message. Please try again later.";
                SuccessMessage = null;
                // Log the exception (optional)
                Console.WriteLine(ex.Message);
            }

            return Page();
        }
    }
}