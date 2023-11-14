using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace I_am_profi.ViewModeks.ForView
{
    public class SkillForView
    {
        public int idSkill { get; set; }        
        public string Name { get; set; }
        public TimeSpan AllTime { get; set; } //сумма минут которые вносятся
        public TimeSpan GoalTime { get; set; } //конечное сумарное варемя 
        public TimeSpan DesiredTime { get; set; } //желаемое время за навыком в неделю
        public int CountRepet { get; set; } //колличество шт. (например сколько книг желаешь прочитать)
        public int CountRepetNaw { get; set; } //сколько уже сделал
        public string WhatIsGoal { get; set; }
        public bool IsKeepTrack { get; set; } //отсллеживать(напоминать)
        public int ProcentSkill { get; set; }
        public DateTime CreateData { get; set; } // Дата создания
        public DateTime EditDateTime { get; set; } //Дата внесения изменений
        public string SkillLevel { get; set; } //уровень мастерства
    }
}
