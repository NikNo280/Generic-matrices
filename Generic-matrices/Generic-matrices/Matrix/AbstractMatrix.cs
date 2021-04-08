using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_matrices.Matrix
{
    public abstract class AbstractMatrix<T>
    {
        private int length;
        private int count;
        protected T[] matrix;

        protected delegate void SetItemDelegate(string message);

        protected event SetItemDelegate SetItemEvent;

        public int Count 
        {
            get
            {
                return this.count;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} is less than or equal to zero");
                }

                this.count = value;
            }
        }

        public int Lenght
        {
            get
            {
                return this.length;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} is less than or equal to zero");
                }

                this.length = value;
            }
        }

        public abstract T this[int i, int j]
        {
            get;
            set;
        }

        protected virtual void SetItem(int i, int j, T item)
        {
            this.SetItemEvent?.Invoke($"matrix element [{i},{j}] has been changed");
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < this.Lenght; i++)
            {
                for (int j = 0; j < this.Lenght; j++)
                {
                    Console.Write(this[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
