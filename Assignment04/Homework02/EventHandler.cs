using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    //声明事件处理委托
    public delegate void AlarmEventHandler(object source, AlarmEventArgs args);
    public delegate void TickEventHandler(object source, TickEventArgs args);
}
