using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlarm.Services
{
    public interface ISetAlarm
    {
        void SetAlarm(DateTimeOffset dateTimeOffs);
        void StopAlarm();
    }
}
