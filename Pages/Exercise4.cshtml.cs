using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise4Model : PageModel
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

        for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++)
            Result.Add(MatrixA[i][j] + MatrixB[i][j]);
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 2)
            .Select(_ => Enumerable.Range(0, 2)
                .Select(_ => rng.Next(1, 100)).ToArray())
            .ToArray();
    }
}
