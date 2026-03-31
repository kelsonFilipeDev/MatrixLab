using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise3Model : BasePage
{
    [BindProperty]
    public int[][] Matrix { get; set; } = GenerateRandom();

    public List<MatrixEntry>? Result { get; set; }

    public IActionResult OnGet() => CheckAuth();

    public void OnPostGenerate()
    {
        Matrix = GenerateRandom();
    }

    public void OnPostExecute()
    {
        Result = new List<MatrixEntry>();

        for (int i = 0; i < 5; i++)
        for (int j = 0; j < 5; j++)
        {
            if ((i + j) % 2 == 0)
                Result.Add(new MatrixEntry(i, j, Matrix[i][j]));
        }
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 5)
            .Select(_ => Enumerable.Range(0, 5)
                .Select(_ => rng.Next(1, 100)).ToArray())
            .ToArray();
    }

    public record MatrixEntry(int Row, int Col, int Value);
}
