using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace I_am_profi.Data
{
    public class Skill
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan AllTime { get; set; }
        public string WhatIsGoal { get; set; }
        public bool IsKeepTrack { get; set; }

        public override string ToString()
        {
            return $"{Name} {AllTime}";
        }
    }
}
