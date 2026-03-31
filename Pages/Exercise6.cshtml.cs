using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise6Model : BasePage
{
    [BindProperty]
    public int[][] Matrix { get; set; } = GenerateRandom();

    public int? Total { get; set; }

    public IActionResult OnGet() => CheckAuth();

    public void OnPostGenerate()
    {
        Matrix = GenerateRandom();
    }

    public void OnPostExecute()
    {
        Total = Matrix.SelectMany(row => row).Sum();
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 4)
            .Select(_ => Enumerable.Range(0, 5)
                .Select(_ => rng.Next(1, 100)).ToArray())
            .ToArray();
    }
}
