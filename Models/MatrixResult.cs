namespace MatrixLab.Models
{
    public class MatrixResult
    {
        public double[,]? ResultMatrix { get; set; }

        public double ScalarResult { get; set; }

        public double[] RowTotals { get; set; } = Array.Empty<double>();

        public double[] ColumnTotals { get; set; } = Array.Empty<double>();
    }
}