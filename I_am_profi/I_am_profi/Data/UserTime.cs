using System;
using System.Collections.Generic;
using System.Text;

namespace I_am_profi.Data
{
   public class UserTime
    {
        public int ID { get; set; }
        public TimeSpan WorkTimeWeek { get; set; }
        public TimeSpan SleepTimeWeek { get; set; }
        public TimeSpan RestTime { get; set; }
    }
}
