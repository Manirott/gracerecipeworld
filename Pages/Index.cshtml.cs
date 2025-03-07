using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace reciepe.Pages
{
    public class IndexModel : PageModel
    {
       
            public string Username { get; set; }

            public void OnGet()
            {
                // Retrieve the username from session
                Username = HttpContext.Session.GetString("Username");
            }
        
    }
}
