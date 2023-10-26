using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace I_am_profi.Data
{
    public class Reminder
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int IdSkill { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
    }
}
