using System;


namespace task11
{
    public delegate void start(object ivent, string name, string time);
    public delegate void left_nr(object ivent, MyEventArgs e);
    public delegate void stop(object ivent, string name, int time);

    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(string arg) { Value = arg; }

        public string Value { get; private set; }
    }

    public interface ICutDownNotifier
    {
        void Init();
        void Run();
    }

    class Program
    {
        static void Main(string[] args)
        {
            start del = Start;
            Action<string, string> timeOver = TimeOver;

            ICutDownNotifier[] classes = new ICutDownNotifier[] {
                new Reading("Чтение задания", del, timeOver),
                new Doing("Выполнение задания", del, timeOver),
                new Checking("Проверка задания перед отправкой", del, timeOver) };

            foreach (var cl in classes)
            {
                cl.Init();
                cl.Run();
            }
            Console.ReadKey();
        }

        static void Start(object ivent, string name, string time)
        {
            Console.WriteLine("Название задачи: " + name);
            Console.WriteLine("Отведено: " + time);
            Console.WriteLine("Источник события: " + ivent);
            Console.WriteLine("Обратный отсчет");
        }

        static void TimeOver(string name, string time)
        {
            Console.WriteLine("Отсчет завершен");
            Console.WriteLine("Название задачи: " + name);
            Console.WriteLine("Отведено: " + time);
            Console.WriteLine();
        }
    }













}
