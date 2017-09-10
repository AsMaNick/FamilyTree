using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Family_Tree
{
    class Timer
    {
        private Stopwatch timer;
        private long lastTime;
        
        public Timer()
        {
            timer = new Stopwatch();
            timer.Start();
            update();
        }

        public void update()
        {
            lastTime = timer.ElapsedMilliseconds;
        }

        public long getTime()
        {
            return timer.ElapsedMilliseconds - lastTime;
        }
    }
}
