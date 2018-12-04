using System;

namespace task11
{
    public class Doing : ICutDownNotifier
    {
        private Timer timer;
        public start del;
        public Action<string, string> timeOver;

        public Doing(string name, start callback, Action<string, string> timeOver)
        {
            timer = new Timer(name);
            del = callback;
            this.timeOver = timeOver;
        }

        public void Init()
        {
            timer.onStart += delegate (object ivent, string name, string time) {
                del(ivent, name, time);
            };

            timer.onLeft += delegate (object ivent, MyEventArgs myEventArgs) {
                Console.WriteLine(myEventArgs.Value + " секунд осталось");
            };

            timer.onStop += delegate (object ivent, string name, int time) {
                timeOver(name, time.ToString());
            };
        }

        public void Run()
        {
            timer.Count();
        }
    }

}
