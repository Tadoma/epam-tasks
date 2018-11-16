using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны треугольника A, B, C: ");
            uint a = UInt32.Parse( Console.ReadLine() );
            uint b = UInt32.Parse(Console.ReadLine());
            uint c = UInt32.Parse(Console.ReadLine());

            Triagle t = new Triagle(a,b,c);
            Console.WriteLine("is triagle exist? : {0}", t.isExist());
            if (!t.isExist()) {
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Площадь: {0}", t.s());
            Console.WriteLine("Периметр: {0}", t.p());
            Console.ReadLine();
           

        }
    }
    public class Triagle
    {
        private uint a, b, c;
        public Triagle(uint a, uint b, uint c)
        {
            if (a == 0 || b == 0 || c == 0) throw new NotSupportedException();
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public bool isExist(){
            if (a+b>c && b+c>a && a+c>b) return true;
            else return false;
        }
        public double s()
        {
            double pp = p() / 2.0;
            return Math.Round(Math.Sqrt(pp*(pp-a)*(pp-b)*(pp-c)),2);
        }
        public uint p()
        {
            return a + b + c;
        }
    }
}
