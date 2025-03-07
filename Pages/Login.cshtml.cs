using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace reciepe.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // Clear session on GET request (optional)
            HttpContext.Session.Remove("Username");
        }

        public IActionResult OnPost()
        {
            // Hardcoded login logic (no database)
            if (Username == "Nafi" && Password == "password")
            {
                // Store the username in session
                HttpContext.Session.SetString("Username", Username);

                // Redirect to the home page or recipe list after successful login
                return RedirectToPage("/Index");
            }

            // If login fails, show an error message
            ErrorMessage = "Invalid username or password";
            return Page();
        }
    }
}