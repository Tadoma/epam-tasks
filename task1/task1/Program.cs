using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace task1
{
    /// <summary>  
    ///  Этот класс содержит точку входа в приложение и основной функционал программы  
    /// </summary> 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Change io mode, 0 - console, 1 - file.");
            string input = Console.ReadLine();

            int mode = Convert.ToInt32(input);
            if (mode == 1)
            {
                foreach (string line in File.ReadLines(@".\numbers.txt"))
                {
                    Point point = Point.Parse(line);
                    printResult(point);
                }
                Console.ReadLine();
            }
            else
            {
                string rawDataInput = Console.ReadLine();
                Point point = Point.Parse(rawDataInput);
                printResult(point);
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Вывод форматированных данных.
	/// </summary>
        static void printResult(Point point)
        {
            Console.WriteLine("X: {0} Y: {1}", Convert.ToDecimal(point.X), Convert.ToDecimal(point.Y));
        }
    }
   
}
