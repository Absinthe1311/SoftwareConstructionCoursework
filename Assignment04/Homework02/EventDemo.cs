using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class EventDemo
    {
        public static void TickMethod(object source, TickEventArgs args)
        {
            Console.WriteLine("The clock tick {0} times", args.TickCount); //输出这个时钟滴答了多少次
        }
        public static void AlarmMethod(object source, AlarmEventArgs args)
        {
            Console.WriteLine("The clock alarms at {0}", args.AlarmTime); //输出这个时钟在什么时候响铃
        }
        public static async Task Main()
        {
            Tick tick = new Tick();
            tick.tickEvent += new TickEventHandler(TickMethod);
            Alarm alarm = new Alarm();
            alarm.alarmEvent += new AlarmEventHandler(AlarmMethod);
            for(int i = 1; i<=100;i++)
            {
                if (i % 2 == 0)
                    tick.ClockTick();
                if (i % 10 == 0)
                    alarm.ClockAlarm(""+DateTime.Now);
                await Task.Delay(500); //每次循环延迟500ms
            }
        }
    }
}
