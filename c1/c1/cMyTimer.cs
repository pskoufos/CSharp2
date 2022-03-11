using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers; 

namespace myTimer
{
    public  class cMyTimer
    {
        internal  System.Timers.Timer timer = new System.Timers.Timer();
        public event EventHandler? TimeElapsed;
        public event EventHandler<TimerEventsArgs>?TimeTick;
        
        private int ticks; 

        public void StartTimer(int ticks)
        {

            this.timer.AutoReset = true;
            this.timer.Interval = 1000;
            this.ticks = ticks;
            this.timer.Enabled = true;
            this.timer.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //TimeElapsed?.Invoke(this, e);
            /*this.timer.Enabled = false; */
            ticks--;
            if (ticks == 0)
            {
                TimeElapsed?.Invoke(this, e);
                this.timer.Enabled = false; 

            }
            else
            {
                TimerEventsArgs e2 = new TimerEventsArgs() ;
                e2.tick = ticks;
                TimeTick?.Invoke(this, e2);

            }
        }

        public void StopTimer()
        {
            timer.Enabled = false; 
        }




    }// cMyTimer

    public class TimerEventsArgs : EventArgs
    {
        public int tick; 
    }

}//namespace 
