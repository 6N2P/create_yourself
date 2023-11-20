using I_am_profi.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace I_am_profi.ViewModeks
{
    public class EditSkillViewModel : BasePropertyChange
    {
        public EditSkillViewModel(int selectedSkillId)
        { 

            _skill = DB.GetSkill( selectedSkillId);
            SkillName = _skill.Name;
            GoalTime = GetGoalTime();
            AllTime = GetAllTime();
            WhatIsGoal=_skill.WhatIsGoal;
            CountRepet = _skill.CountRepet;
            CountRepetNow = _skill.CountRepetNaw;
            AddTime = new Command(AddT);
            TakeAwayTime = new Command(TakeAway);
            EditSkill = new Command(Edit);
        }

       

        public delegate void EditSkillHandler();
        public event EditSkillHandler EditSkillEvent;

        private Skill _skill;

        private string _skillName;
        private int _minuts;
        private string _allTime;
        private string _whatIsGoal;
        private string _goalTime;
        private static DB dB;
        private  int _countRepet;
        private int _countRepeteNow;

        public int CountRepetNow
        {
            get => _countRepeteNow;
            set
            {
                _countRepeteNow = value;
                OnPropertyChanged(nameof(CountRepetNow));
            }
        }
        public  int CountRepet
        {
            get => _countRepet;
            set
            {
                _countRepet = value;
                OnPropertyChanged(nameof(CountRepet));
            }
        }
        public static DB DB
        {
            get
            {
                if (dB is null) dB = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "skillDB.sqlite3"));
                return dB;
            }
        }
        public string GoalTime
        {
            get => _goalTime;
            set
            {
                _goalTime = value;
                OnPropertyChanged(nameof(GoalTime));
            }
        }
        public string WhatIsGoal
        {
            get => _whatIsGoal;
            set
            {
                _whatIsGoal = value;
                OnPropertyChanged(nameof(WhatIsGoal));
            }
        }
        public int Minuts
        {
            get => _minuts;
            set
            {
                if(value > 0)
                {
                    _minuts = value;
                    OnPropertyChanged(nameof(Minuts));
                }
            }
        }
        public string SkillName
        {
            get => _skillName;
            set
            {
                _skillName = value;
                OnPropertyChanged("SkillName");
            }
        }
        public string AllTime
        {
            get => _allTime;
            set
            {
                _allTime = value;
                OnPropertyChanged($"{nameof(AllTime)}");
            }
        }
        

        public ICommand AddTime { get; }
        public ICommand TakeAwayTime { get; }
        public ICommand EditSkill { get; }


        private void AddT()
        {
            var timeAll = ConvertToTime(AllTime);
            AllTime = GetAllTime((timeAll + TimeSpan.FromMinutes(Minuts)));
        }



        private void TakeAway()
        {
            var timeAll = ConvertToTime(AllTime);
            AllTime = GetAllTime((timeAll - TimeSpan.FromMinutes(Minuts)));
        }

        private TimeSpan ConvertToTime(string timeString)
        {
            TimeSpan result = TimeSpan.Zero;
            int days = 0;
            int hors = 0;
            int minuts = 0;
            if (!string.IsNullOrEmpty(timeString))
            {
                var time = timeString.Split(':');

                TimeSpan d = TimeSpan.FromHours(int.Parse(time[0]));
                days = d.Days;

                hors = Convert.ToInt32(time[0]) - days * 24; ;
                minuts = Convert.ToInt32(time[1]);

                result = new TimeSpan(days, hors, minuts,0);
            }

            return result;
        }
        private string GetGoalTime()
        {
            var day = _skill.GoalTime.Days;
            var hours = _skill.GoalTime.Hours;
            var minutes = _skill.GoalTime.Minutes;
            return $"{day * 24 + hours}:{minutes}";
        }
        private string GetAllTime(TimeSpan timeSpan)
        {
            var day = timeSpan.Days;
            var hours = timeSpan.Hours;
            var minutes = timeSpan.Minutes;
            return $"{day * 24 + hours}:{minutes}";
        }
        private string GetAllTime()
        {
            var day = _skill.AllTime.Days;
            var hours = _skill.AllTime.Hours;
            var minutes = _skill.AllTime.Minutes;
            return $"{day * 24 + hours}:{minutes}";
        }

        private void Edit()
        {
            _skill.AllTime = ConvertToTime( AllTime);
            _skill.CountRepet = CountRepet;
            _skill.CountRepetNaw = CountRepetNow;
            _skill.ProcentSkill = GetProcent();
            _skill.WhatIsGoal = WhatIsGoal;
            _skill.EditDateTime = DateTime.Now;

            DB.ChangeTimeAlltSkill( _skill );
            EditSkillEvent?.Invoke();
        }

        private int GetProcent()
        {
            double procentTime = 0;
            double procentCount = 0;
            int result = 0;

            if(CountRepet == 1)
            {
                double gd = ConvertToTime(GoalTime).Days;
                double gH = ConvertToTime(GoalTime).Hours;
                double g = ConvertToTime(GoalTime).Minutes;
                double gTime = gd * 1440 + gH * 60 + g;

                double ad = ConvertToTime(AllTime).Days;
                double aH = ConvertToTime(AllTime).Hours;
                double a = ConvertToTime(AllTime).Minutes;
                double aTime = ad * 1440 + aH * 60 + a;
                procentTime = (100 / gTime) * aTime;
                result = Convert.ToInt32(procentTime);
            }
            else
            {
                procentCount = 100 * CountRepetNow / CountRepet ;
                result = Convert.ToInt32(procentCount);
            }
            return result;
        }

       
    }
}
