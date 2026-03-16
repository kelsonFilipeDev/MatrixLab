namespace MatrixLab.Models
{
    public class MatrixRequest
    {
        public ExerciseType Exercise { get; set; }

        public double[,] MatrixA { get; set; }

        public double[,] MatrixB { get; set; }
    }
}