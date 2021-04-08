using System;
using NUnit.Framework;
using Generic_matrices.Matrix;

#pragma warning disable CA1707

namespace Generic_matrices.Tests
{
    public class Generic_matricesTests
    {
        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesSum))]
        public void SumByDynamicMatrix<T>(AbstractMatrix<T> abstractMatrix1, AbstractMatrix<T> abstractMatrix2, AbstractMatrix<T> result)
        {
            var matrix3 = abstractMatrix1.SumByDynamic(abstractMatrix2);
            for (int i = 0; i < abstractMatrix1.Lenght; i++)
            {
                for (int j = 0; j < abstractMatrix1.Lenght; j++)
                {
                    Assert.AreEqual(result[i, j], matrix3[i, j]);
                }
            }
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesSum))]
        public void SymByExpressionMatrix<T>(AbstractMatrix<T> abstractMatrix1, AbstractMatrix<T> abstractMatrix2, AbstractMatrix<T> result)
        {
            var matrix3 = abstractMatrix1.SymByExpression(abstractMatrix2);
            for (int i = 0; i < abstractMatrix1.Lenght; i++)
            {
                for (int j = 0; j < abstractMatrix1.Lenght; j++)
                {
                    Assert.AreEqual(result[i, j], matrix3[i, j]);
                }
            }
        }
    }
}
