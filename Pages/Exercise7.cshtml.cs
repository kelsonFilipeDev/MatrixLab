using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise7Model : BasePage
{
    [BindProperty]
    public int[][] Matrix { get; set; } = GenerateRandom();

    public List<int>? Result { get; set; }

    public IActionResult OnGet() => CheckAuth();

    public void OnPostGenerate()
    {
        Matrix = GenerateRandom();
    }

    public void OnPostExecute()
    {
        // Copia profunda para não alterar o original durante operações
        int[][] m = Matrix.Select(row => row.ToArray()).ToArray();

        // 1. Trocar 2ª linha (index 1) pela 5ª linha (index 4)
        (m[1], m[4]) = (m[4], m[1]);

        // 2. Trocar 3ª coluna (index 2) pela 5ª coluna (index 4)
        for (int i = 0; i < 5; i++)
            (m[i][2], m[i][4]) = (m[i][4], m[i][2]);

        // 3. Trocar diagonal principal pela diagonal secundária
        for (int i = 0; i < 5; i++)
            (m[i][i], m[i][4 - i]) = (m[i][4 - i], m[i][i]);

        Result = m.SelectMany(row => row).ToList();
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 5)
            .Select(_ => Enumerable.Range(0, 5)
                .Select(_ => rng.Next(1, 100)).ToArray())
            .ToArray();
    }
}
