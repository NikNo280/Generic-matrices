using System.Collections.Generic;
using Generic_matrices.Matrix;
using NUnit.Framework;

#pragma warning disable SA1600

namespace Generic_matrices.Tests
{
    internal class TestCasesDataSource
    {
        public static IEnumerable<TestCaseData> TestCasesSum
        {
            get
            {
                yield return new TestCaseData(
                     new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                     new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                     new SquareMatrix<int>(new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } }));

                yield return new TestCaseData(
                     new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                     new DiagonalMatrix<int>(new int[,] { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } }),
                     new SquareMatrix<int>(new int[,] { { 3, 2, 3 }, { 4, 15, 6 }, { 7, 8, 27 } }));
                yield return new TestCaseData(
                     new DiagonalMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                     new DiagonalMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                     new DiagonalMatrix<int>(new int[,] { { 2, 0, 0 }, { 0, 10, 0}, { 0, 0, 18 } }));
                yield return new TestCaseData(
                     new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 5, 6 }, { 3, 6, 9 } }),
                     new DiagonalMatrix<int>(new int[,] { { 2, 0, 0 }, { 0, 10, 0 }, { 0, 0, 18 } }),
                     new SymmetricMatrix<int>(new int[,] { { 3, 2, 3 }, { 2, 15, 6 }, { 3, 6, 27 } }));
            }
        }
    }
}
