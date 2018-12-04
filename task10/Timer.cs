using System;
using System.Threading;

namespace task11
{
    class Timer
    {
        public string name;
        public event start onStart;
        public event left_nr onLeft;
        public event stop onStop;     

        public Timer(string name)
        {
            this.name = name;
        }

        public void Count()
        {
            Console.Write("Введите время: ");
            int time = int.Parse(Console.ReadLine());
            Console.WriteLine();

            onStart(this, name, time.ToString());

            for (int i = time; i != 0; i--)
            {
                onLeft(this, new MyEventArgs(i.ToString()));
                Thread.Sleep(1000);

                if (i == 1)
                {
                    onStop(this, name, time);
                }
            }
        }
    }
}
