using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MatrixLab.Pages;

public class Exercise8Model : PageModel
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

    public void OnGet() { }

    public void OnPostGenerate()
    {
        Matrix = GenerateRandom();
    }

    public void OnPostExecute()
    {
        var monthTotals = Matrix.Select(row => row.Sum()).ToArray();

        var weekTotals = Enumerable.Range(0, 4)
            .Select(j => Matrix.Sum(row => row[j]))
            .ToArray();

        var yearTotal = monthTotals.Sum();

        Result = new SalesResult(monthTotals, weekTotals, yearTotal);
    }

    private static int[][] GenerateRandom()
    {
        var rng = new Random();
        return Enumerable.Range(0, 12)
            .Select(_ => Enumerable.Range(0, 4)
                .Select(_ => rng.Next(100, 10000)).ToArray())
            .ToArray();
    }

    public record SalesResult(int[] MonthTotals, int[] WeekTotals, int YearTotal);
}
