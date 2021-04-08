using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Generic_matrices.Matrix;

namespace Generic_matrices
{
    public static class MatrixExtension
    {
        public static AbstractMatrix<T> SumByDynamic<T>(this AbstractMatrix<T>  matrix1, AbstractMatrix<T> matrix2)
        {
            if (matrix1.Lenght != matrix2.Lenght)
            {
                throw new ArgumentException("Matrixs must have same lenght");
            }

            var resultMatrix = new T[matrix1.Lenght, matrix1.Lenght];
            for (int i = 0; i < matrix1.Lenght; i++)
            {
                for (int j = 0; j < matrix1.Lenght; j++)
                {
                    T result;
                    try
                    {
                        result = (T)((dynamic)matrix1[i, j] + matrix2[i, j]);
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        throw new NotSupportedException(nameof(T), ex);
                    }
                    resultMatrix[i, j] = result;
                }
            }

            int maxCount = matrix1.Count > matrix2.Count ? matrix1.Count : matrix2.Count;
            if (maxCount == matrix1.Lenght *  matrix1.Lenght)
            {
                return new SquareMatrix<T>(resultMatrix);
            }
            else if (maxCount == matrix1.Lenght)
            {
                return new DiagonalMatrix<T>(resultMatrix);
            }
            else
            {
                return new SymmetricMatrix<T>(resultMatrix);
            }
        }


        public static AbstractMatrix<T> SymByExpression<T>(this AbstractMatrix<T> matrix1, AbstractMatrix<T> matrix2)
        {
            if (matrix1.Lenght != matrix2.Lenght)
            {
                throw new ArgumentException("Matrixs must have same lenght");
            }

            var resultMatrix = new T[matrix1.Lenght, matrix1.Lenght];
            for (int i = 0; i < matrix1.Lenght; i++)
            {
                for (int j = 0; j < matrix1.Lenght; j++)
                {
                    T result;
                    try
                    {
                        result = Add<T>()(matrix1[i, j], matrix2[i, j]);
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new NotSupportedException("", ex); ;
                    }
                    resultMatrix[i, j] = result;
                }
            }

            int maxCount = matrix1.Count > matrix2.Count ? matrix1.Count : matrix2.Count;
            if (maxCount == matrix1.Lenght * matrix1.Lenght)
            {
                return new SquareMatrix<T>(resultMatrix);
            }
            else if (maxCount == matrix1.Lenght)
            {
                return new DiagonalMatrix<T>(resultMatrix);
            }
            else
            {
                return new SymmetricMatrix<T>(resultMatrix);
            }
        }

        private static Func<T, T, T> Add<T>()
        {
            ParameterExpression paramL = Expression.Parameter(typeof(T), "lhs"),
                                paramR = Expression.Parameter(typeof(T), "rhs");
            BinaryExpression add = Expression.Add(paramL, paramR);
            Func<T, T, T> sum = Expression.Lambda<Func<T, T, T>>(add, paramL, paramR).Compile();
            return sum;
        }
    }
}
