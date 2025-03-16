using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//此文件用于声明提供事件数据的类

namespace Assignment4
{
    //Tick事件
    public class TickEventArgs : EventArgs
    {
        public int TickCount { get; set; }  //用来记录Tick的次数
        public TickEventArgs(int tickCount)
        {
            this.TickCount = tickCount;
        }
    }
    public class AlarmEventArgs : EventArgs
    {
        public string AlarmTime { get; set; }   //用来记录响铃的时间
        public AlarmEventArgs(string alarmTime)
        {
            this.AlarmTime = alarmTime;
        }
    }
}
