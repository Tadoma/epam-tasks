using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Euclidean.timeCalc(100, 50);
            Euclidean.timeGCD(56, 68);
            Console.ReadLine();
        }
    }
    public class Euclidean
    {
        public static int calc(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int calcExtended(params int[] n)
        {
            if (n.Length == 0) return 0;
            int i, gcd = n[0];
            for (i = 0; i < n.Length - 1; i++)
                gcd = calc(gcd, n[i + 1]);
            return gcd;
        }

        public static void timeCalc(params int[] n)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine("Алгоритм Евклида: результат {0}", calcExtended(n));

            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(" выполнено за {0}", ts.ToString());
        }

        public static long GCD(long a, long b)
        {
            if (a == 0)
                return b;                            
            if (b == 0)
                return a;                            
            if (a == b)
                return a;                            
            if (a == 1 || b == 1)
                return 1;                            
            if ((a & 1) == 0)                        
                return ((b & 1) == 0)
                    ? GCD(a >> 1, b >> 1) << 1       
                    : GCD(a >> 1, b);                
            else                                     
                return ((b & 1) == 0)
                    ? GCD(a, b >> 1)                 
                    : GCD(b, a > b ? a - b : b - a);
        }
        public static void timeGCD(long a, long b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine("Алгоритм Стейна: результат {0}", GCD(a, b));

            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(" выполнено за {0}", ts.ToString());
        }

    }
}
