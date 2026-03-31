using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class IndexModel : BasePage
{
    public IActionResult OnGet() => CheckAuth();
}
