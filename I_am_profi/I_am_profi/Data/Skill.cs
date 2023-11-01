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
        public TimeSpan AllTime { get; set; } //сумма минут которые вносятся
        public TimeSpan GoalTime { get; set; } //конечное сумарное варемя 
        public TimeSpan DesiredTime { get; set; } //желаемое время за навыком в неделю
        public int CountRepet { get; set; } //колличество шт. (например сколько книг желаешь прочитать)
        public int CountRepetNaw { get; set; } //сколько уже сделал
        public string WhatIsGoal { get; set; } 
        public bool IsKeepTrack { get; set; } //отсллеживать(напоминать)

        public override string ToString()
        {
            return $"{Name} {AllTime} нужно времени {GoalTime} сдел. {CountRepetNaw} всего: {CountRepet}";
        }
    }
}
