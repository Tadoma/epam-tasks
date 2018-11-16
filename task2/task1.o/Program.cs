using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.o
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            double num = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите степень корня");
            double e = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность");
            double est = Double.Parse(Console.ReadLine());
            Calculation c = new Calculation(est);
            Console.WriteLine("Результат вычисления методом Ньютона: ");
            Console.WriteLine(c.SqrtN(e, num));
            Console.WriteLine("Результат вычисления с использованием Math.Pow: ");
            Console.WriteLine(Math.Pow(num, 1/e));
            Console.ReadLine();
            
        }
    }
    class Calculation
    {
        double eps;
        public Calculation(double eps)
        {
            this.eps = eps;
        }
        public double SqrtN(double n, double A)
        {
            var x0 = A / n;
            var x1 = (1 / n) * ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1));
            }

            return x1;
        }
    }
}
