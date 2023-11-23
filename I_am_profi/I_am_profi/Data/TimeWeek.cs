using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace I_am_profi.Data
{
    public class TimeWeek
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int idSkell { get; set; }
        public DateTime DateEdit { get; set; }
        public TimeSpan TimeMonday { get; set; } = TimeSpan.Zero;
        public TimeSpan TimeTuesday { get; set;} = TimeSpan.Zero;
        public TimeSpan TimeWednesday { get; set; } = TimeSpan.Zero;
        public TimeSpan TimeThursday { get;set; } = TimeSpan.Zero;
        public TimeSpan TimeFriday { get; set; } = TimeSpan.Zero;
        public TimeSpan TimeSaturday { get; set; } = TimeSpan.Zero;
        public TimeSpan TimeSunday { get; set; } = TimeSpan.Zero;
    }
}
