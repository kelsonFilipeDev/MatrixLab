using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise5Model : PageModel
{
    [BindProperty]
    public int[][] MatrixA { get; set; } = GenerateRandom();

    [BindProperty]
    public int[][] MatrixB { get; set; } = GenerateRandom();

    public List<int>? Result { get; set; }

    public void OnGet() { }

    public void OnPostGenerate()
    {
        MatrixA = GenerateRandom();
        MatrixB = GenerateRandom();
    }

    public void OnPostExecute()
    {
        Result = new List<int>();

        for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            Result.Add(MatrixA[i][j] - MatrixB[i][j]);
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
