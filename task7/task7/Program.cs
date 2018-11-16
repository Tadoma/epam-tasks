using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    public class Matrix
    {
        private int[,] array;
        public int[,] GetRaw()
        {
            return array;
        }
        public Matrix(int row, int column)
        {
            array = new int[row, column];
            Program.writeMatrix(array);
        }
        public Matrix(int [,] array)
        {
            this.array = array;
        }
        int[,] GetEmpty(int row, int column)
        {
            int[,] emptyArray = new int[row, column];
            return emptyArray;
        }
        public static int[,] mult(Matrix am, Matrix bm)
        {
            var a = am.array;
            var b = bm.array;

            if (a.GetLength(1) != b.GetLength(0)) throw new MatrixException("Матрицы нельзя перемножить, матрицы несогласованы, столбцы a - {0}, строки b - {1}", a.GetLength(1), b.GetLength(0));
            int[,] result = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public static int[,] diff(Matrix am, Matrix bm)
        {
            var a = am.array;
            var b = bm.array;

            int[,] result = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }
        public static int[,] add(Matrix am, Matrix bm)
        {
            var a = am.array;
            var b = bm.array;

            int[,] result = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

    }

    class MatrixException : System.Exception
    {
        private int row;
        private int column;
        private string msg;
        public MatrixException() { }
        public MatrixException(string msg) { this.msg = msg; }
        public MatrixException(string msg, int row, int column)
        {
            this.msg = msg;
            this.row = row;
            this.column = column;
        }
        public override string Message
        {
            get
            {
                return msg;
            }
        }

    }

    class Program
    {
        public static void writeMatrix(int[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("Matrix[{0},{1}] = ", i, j);
                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        static void PrintMatrix(Matrix am)
        {
            var a = am.GetRaw();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Матрица a:");
            Matrix a = new Matrix(2, 2);

            Console.WriteLine("Матрица b:");
            Matrix b = new Matrix(2, 2);

            Matrix c = new Matrix(Matrix.mult(a, b));
            PrintMatrix(c);
        }
    }
}
