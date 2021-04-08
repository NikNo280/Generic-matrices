using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_matrices.Matrix
{
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        public DiagonalMatrix(T[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} is null");
            }

            if (matrix.Length < 1)
            {
                throw new ArgumentException($"{nameof(matrix)} is empty");
            }

            int rows = matrix.GetUpperBound(0) + 1;
            this.Lenght = matrix.Length / rows;
            if (this.Lenght != rows)
            {
                throw new ArgumentException($"{nameof(matrix)} is not square");
            }

            this.Count = this.Lenght;
            this.matrix = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                this.matrix[i] = matrix[i, i];
            }

            this.SetItemEvent += this.PrintMessage;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= this.Lenght || j >= this.Lenght)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }

                if (i != j)
                {
                    return default(T);
                }
                else
                {
                    return this.matrix[i];
                }
            }

            set
            {
                if (i < 0 || j < 0 || i >= this.Lenght || j >= this.Lenght)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }

                this.SetItem(i, j, value);
            }
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        protected override void SetItem(int i, int j, T item)
        {
            if (i == j)
            {
                this.matrix[i] = item;
                base.SetItem(i, j, item);
            }
        }
    }
}
