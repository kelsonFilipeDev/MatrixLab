using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise2Model : PageModel
{
    [BindProperty]
    public int[][] Matrix { get; set; } = GenerateRandom();

    public List<int>? Result { get; set; }

    public void OnGet() { }

    public void OnPostGenerate()
    {
        Matrix = GenerateRandom();
    }

    public void OnPostExecute()
    {
        Result = Matrix.SelectMany(row => row.Select(val => val * 2)).ToList();
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 3)
            .Select(_ => Enumerable.Range(0, 3)
                .Select(_ => rng.Next(1, 100)).ToArray())
            .ToArray();
    }
}
