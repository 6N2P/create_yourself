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
        public EditSkillViewModel(Skill selectedSkill)
        { 
            _skill = selectedSkill;
            SkillName = _skill.Name;
            GoalTime = (DateTime.MinValue + _skill.GoalTime).ToString("HH:mm");
            AllTime = (DateTime.MinValue + _skill.AllTime).ToString("HH:mm");
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
            AllTime=(timeAll+TimeSpan.FromMinutes( Minuts)).ToString();
        }

        private void TakeAway()
        {
            var timeAll = ConvertToTime(AllTime);
            AllTime = (timeAll - TimeSpan.FromMinutes(Minuts)).ToString();
        }

        private TimeSpan ConvertToTime(string timeString)
        {
            TimeSpan result = TimeSpan.Zero;
            TimeSpan hors = TimeSpan.Zero;
            TimeSpan minuts = TimeSpan.Zero;
            if (!string.IsNullOrEmpty(timeString))
            {

                result = TimeSpan.Parse(timeString);
            }

            return result;
        }

        private void Edit()
        {
            _skill.AllTime = ConvertToTime( AllTime);
            _skill.CountRepet = CountRepet;
            _skill.CountRepetNaw = CountRepetNow;

            DB.ChangeTimeAlltSkill( _skill );
            EditSkillEvent?.Invoke();
        }
    }
}
