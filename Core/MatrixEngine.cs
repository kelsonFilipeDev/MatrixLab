using MatrixLab.Models;

namespace MatrixLab.Core
{
    public class MatrixEngine
    {
        public MatrixResult Process(MatrixRequest request)
        {
            return request.Exercise switch
            {
                ExerciseType.DisplayMatrix => ExecuteDisplayMatrix(request),

                ExerciseType.MultiplyMatrixByTwo => ExecuteMultiplyMatrixByTwo(request),

                ExerciseType.FilterEvenRowsAndColumns => ExecuteFilterEvenRowsAndColumns(request),

                ExerciseType.SumMatrices => ExecuteSumMatrices(request),

                ExerciseType.SubtractMatrices => ExecuteSubtractMatrices(request),

                ExerciseType.SumAllElements => ExecuteSumAllElements(request),

                ExerciseType.TransformMatrix => ExecuteTransformMatrix(request),

                ExerciseType.MonthlySalesAnalysis => ExecuteMonthlySalesAnalysis(request),

                ExerciseType.ProductSalesAnalysis => ExecuteProductSalesAnalysis(request),

                _ => new MatrixResult()
            };
        }

        private MatrixResult ExecuteDisplayMatrix(MatrixRequest request)
        {
            return new MatrixResult
            {
                ResultMatrix = request.MatrixA
            };
        }

        private MatrixResult ExecuteMultiplyMatrixByTwo(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteFilterEvenRowsAndColumns(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteSumMatrices(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteSubtractMatrices(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteSumAllElements(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteTransformMatrix(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteMonthlySalesAnalysis(MatrixRequest request)
        {
            return new MatrixResult();
        }

        private MatrixResult ExecuteProductSalesAnalysis(MatrixRequest request)
        {
            return new MatrixResult();
        }
    }
}