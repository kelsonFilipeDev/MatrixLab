using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise9Model : BasePage
{
    [BindProperty]
    public int[][] Matrix { get; set; } = GenerateRandom();

    public SalesResult? Result { get; set; }

    public string[] Months { get; } =
    [
        "Janeiro", "Fevereiro", "Março", "Abril",
        "Maio", "Junho", "Julho", "Agosto",
        "Setembro", "Outubro", "Novembro", "Dezembro"
    ];

    public IActionResult OnGet() => CheckAuth();

    public void OnPostGenerate()
    {
        Matrix = GenerateRandom();
    }

    public void OnPostExecute()
    {
        var monthTotals = Matrix.Select(row => row.Sum()).ToArray();

        var productTotals = Enumerable.Range(0, 5)
            .Select(j => Matrix.Sum(row => row[j]))
            .ToArray();

        Result = new SalesResult(monthTotals, productTotals);
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 12)
            .Select(_ => Enumerable.Range(0, 5)
                .Select(_ => rng.Next(10, 500)).ToArray())
            .ToArray();
    }

    public record SalesResult(int[] MonthTotals, int[] ProductTotals);
}
