using System;

namespace task11
{
    public class Checking : ICutDownNotifier
    {
        private Timer timer;
        public start del;
        public Action<string, string> timeOver;

        public Checking(string name, start callback, Action<string, string> timeOver)
        {
            timer = new Timer(name);
            del = callback;
            this.timeOver = timeOver;
        }

        public void Init()
        {
            timer.onStart += (object ivent, string name, string time) =>
            {
                del(ivent, name, time);
            };
            timer.onLeft += (object ivent, MyEventArgs myEventArgs) =>
            {
                Console.WriteLine(myEventArgs.Value + " секунд осталось");
            };
            timer.onStop += (object ivent, string name, int time) =>
            {
                timeOver(name, time.ToString());
            };
        }

        public void Run()
        {
            timer.Count();
        }
    }
}
