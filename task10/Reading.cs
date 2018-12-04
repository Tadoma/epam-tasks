using System;

namespace task11
{
    public class Reading : ICutDownNotifier
    {
        private Timer timer;
        public start del;
        public Action<string, string> timeOver;


        public Reading(string name, start callback, Action<string, string> timeOver)
        {
            timer = new Timer(name);
            del = callback;
            this.timeOver = timeOver;
        }

        public void Init()
        {
            timer.onStart += Start;
            timer.onLeft += TimeLeft;
            timer.onStop += Stop;
        }

        public void Run()
        {
            timer.Count();
        }

        public void Start(object ivent, string name, string time)
        {
            del(ivent, name, time);
        }

        public void TimeLeft(object ivent, MyEventArgs myEventArgs)
        {
            Console.WriteLine(myEventArgs.Value + " секунд осталось");
        }

        public void Stop(object ivent, string name, int time)
        {
            timeOver(name, time.ToString());
        }
    }

}
