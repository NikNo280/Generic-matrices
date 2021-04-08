using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_matrices.Matrix
{
    public class SymmetricMatrix<T> : AbstractMatrix<T>
    {
        public SymmetricMatrix(T[,] matrix)
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

            this.Count = ((matrix.Length - this.Lenght) / 2) + this.Lenght;
            this.matrix = new T[this.Count];
            int k = 0, index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = k; j < this.Lenght; j++)
                {
                    this.matrix[index] = matrix[i, j];
                    index++;
                }

                k++;
            }

            this.SetItemEvent += PrintMessage;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= this.Lenght || j >= this.Lenght)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }

                if (i > j)
                {
                    (i, j) = (j, i);
                }

                int index = 0;
                for (int k = 0; k < i; k++)
                {
                    index += this.Lenght - k - 1;
                }

                return this.matrix[index + j];
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
            this[i, j] = item;
            base.SetItem(i, j, item);
        }
    }
}
