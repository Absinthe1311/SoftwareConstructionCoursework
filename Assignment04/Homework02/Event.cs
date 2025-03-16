using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 用于声明引发事件的类

namespace Assignment4
{
    class Tick
    {
        ArrayList list;
        //在事件生产类中声明事件
        public event TickEventHandler tickEvent;
        public Tick()
        {
            list = new ArrayList();
        }
        public void ClockTick()
        {
            list.Add(1);
            if(tickEvent!=null)
            {
                tickEvent(this, new TickEventArgs(list.Count));
            }
        }
    }
    class Alarm
    {
        ArrayList list;
        public event AlarmEventHandler alarmEvent;
        public Alarm()
        {
            list = new ArrayList();
        }
        public void ClockAlarm(string time)
        {
            list.Add(time);
            if(alarmEvent !=null)
            {
                alarmEvent(this, new AlarmEventArgs(time));
            }
        }
    }
}
