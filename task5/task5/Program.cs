using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x, y, z для вектора a: ");
            int x = Int32.Parse(Console.ReadLine());
            int y = Int32.Parse(Console.ReadLine());
            int z = Int32.Parse(Console.ReadLine());
            Vector a = new Vector(x, y, z);

            Console.WriteLine("Введите x, y, z для вектора b: ");
            int x1 = Int32.Parse(Console.ReadLine());
            int y1 = Int32.Parse(Console.ReadLine());
            int z1 = Int32.Parse(Console.ReadLine());
            Vector b = new Vector(x1, y1, z1);

            Vector c = a - b;
            Vector d = a + b;
            double scal = a * b;
            Vector f = a ^ b;

            Console.WriteLine(" a - b = {0}\n a + b = {1}\n Скалярное произведение = {2}\n Векторное произведение = {3}\n", c, d, scal, f);
            Console.ReadLine();

            /*
             * 
             */


            Dictionary<char, double> dict1 = new Dictionary<char, double>();
            Dictionary<char, double> dict2 = new Dictionary<char, double>();

            Console.WriteLine("Введите размер многочлена a: ");
            int n1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите размер многочлена b: ");
            int n2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите элементы многочлена 'a' в формате: (x -> 10) ");
            for(int i = 0; i<n1; i++)
            {
                char ch = Char.Parse(Console.ReadLine());
                double key = Double.Parse(Console.ReadLine());
                dict1.Add(ch, key);
            }

            Console.WriteLine("Введите элементы многочлена 'b' в формате: (x -> 10) ");
            for (int i = 0; i < n2; i++)
            {
                char ch = Char.Parse(Console.ReadLine());
                double key = Double.Parse(Console.ReadLine());
                dict2.Add(ch, key);
            }
            Console.WriteLine("Ввод завершен.");

            Poly p1 = new Poly(dict1);
            Poly p2 = new Poly(dict2);
            Console.WriteLine("Введенные многочлены \n\t a: {0}\n\t b: {1}", p1, p2);
            Poly p3 = p1 + p2;
            Poly p4 = p1 - p2;
            
            Console.WriteLine("Сложение  : {0}", p3);
            Console.WriteLine("Вычитание : {0}", p4);

            Console.ReadLine();

        }
    }
    public class Vector
    {
        private int x, y, z;
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        override
        public string ToString()
        {
            string str = "(" + x + ", " + y + ", " + z + ")";
            return str;
        }
        public static Vector operator + (Vector v, Vector v1)
        {
            return new Vector(v.x + v1.x, v.y + v1.y, v.z + v1.z);
        }
        public static Vector operator - (Vector v, Vector v1)
        {
            return new Vector(v.x - v1.x, v.y - v1.y, v.z - v1.z);
        }
        public static double operator * (Vector v, Vector v1)
        {
            return v.x * v1.x + v.y * v1.y + v.z * v1.z;
        }
        public static Vector operator ^ (Vector v, Vector v1)
        {
            return new Vector(v.y*v1.z - v.z*v1.y, v.z*v1.x - v.x*v1.z, v.x*v1.y - v.y*v1.x);
        }
    }
    public class Poly
    {
        private Dictionary<char, double> data = new Dictionary<char, double>();
        public Poly(Dictionary<char, double> data)
        {
            this.data = data;
        }
        public static Poly operator +(Poly p1, Poly p2)
        {
            Dictionary<char, double> newData = new Dictionary<char, double>();

            var result = newData.Concat(p1.data).Concat(p2.data)
                        .GroupBy(x => x.Key)
                   .ToDictionary(x => x.Key, x => x.Sum(y => y.Value));

            return new Poly(result);
        }
        public static Poly operator -(Poly p1, Poly p2)
        {
            Dictionary<char, double> newData = new Dictionary<char, double>();
            Dictionary<char, double> p2c = new Dictionary<char, double>(p2.data);

            foreach (var key in p2c.Keys.ToList())
            {
                p2c[key] *= -1;
            }

            var result = newData.Concat(p1.data).Concat(p2c)
                        .GroupBy(x => x.Key)
                   .ToDictionary(x => x.Key, x => x.Sum(y => y.Value));

            return new Poly(result);
        }
        override
        public string ToString()
        {
            StringBuilder result = new StringBuilder();
            bool onCheck = true;
            foreach (KeyValuePair<char, double> entry in data)
            {
                if (data.Values.First().Equals(entry.Value) && onCheck && entry.Value != 0)
                {
                    result.Append(entry.Value + "" + entry.Key);
                    onCheck=!onCheck;
                }
                else
                {
                    if (entry.Value == 0) continue;
                    var cond = (entry.Value > 0) ? result.Append("+" + entry.Value + "" + entry.Key) : result.Append(entry.Value + "" + entry.Key);
                }
            }
            return result.ToString();
        }
    }
}
