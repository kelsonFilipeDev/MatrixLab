using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class BasePage : PageModel
{
    public IActionResult CheckAuth()
    {
        if (HttpContext.Session.GetString("auth") != "true")
            return RedirectToPage("/Login");

        return Page();
    }
}
