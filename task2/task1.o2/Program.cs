using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.o2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите десятичное неотрицательное число");
            int num = Int32.Parse(Console.ReadLine());
            Translation tr = new Translation(num);

            Console.WriteLine("Результат via Convert: ");
            Console.WriteLine(tr.translateViaNet());

            Console.WriteLine("Результат путём своего алгоритма: ");
            Console.WriteLine(tr.translate());

            Console.ReadLine();
        }
    }
    class Translation
    {
        int num;
        public Translation(int num)
        {
            this.num = num;
        }
        public string translateViaNet()
        {
            return Convert.ToString(num, 2);
        }
        public string translate()
        {
            string result = "";
            while(num != 0)
            {
                int a = num % 2;
                num = num / 2;
                result += a;
            }
            return new string(result.ToCharArray().Reverse().ToArray());
        }

    }
}
