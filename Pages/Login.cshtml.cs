using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class LoginModel : PageModel
{
    private const string ValidUsername = "admin";
    private const string ValidPassword = "admin123";

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public bool Error { get; set; } = false;

    public IActionResult OnGet()
    {
        if (HttpContext.Session.GetString("auth") == "true")
            return RedirectToPage("/Index");

        return Page();
    }

    public IActionResult OnPost()
    {
        if (Username == ValidUsername && Password == ValidPassword)
        {
            HttpContext.Session.SetString("auth", "true");
            return RedirectToPage("/Index");
        }

        Error = true;
        return Page();
    }
}
