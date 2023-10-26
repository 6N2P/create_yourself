using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace I_am_profi.Data
{
    public class Revard
    {
        [PrimaryKey,AutoIncrement]
        public int ID {  get; set; }
        public string RevardName { get; set; }
        public int IdSkill { get; set; }
        public TimeSpan atWhatTime { get; set; }
        public int atWhatCount { get; set; }
        public bool TrackByTime { get; set; }
    }
}
