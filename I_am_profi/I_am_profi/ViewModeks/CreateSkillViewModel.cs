using I_am_profi.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace I_am_profi.ViewModeks
{
    public class CreateSkillViewModel : BasePropertyChange
    {

        public CreateSkillViewModel() 
        {
            SkillName = "Навык";
            CountRepet = 1;
            CreateSkillCommand = new Command(CreateSkill);
        }

        public delegate void CreateSkillHandler();
        public event CreateSkillHandler CreateSkillEvent;

        private static DB dB;
        public static DB DB
        {
            get
            {
                if (dB is null) dB = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "skillDB.sqlite3"));
                return dB;
            }
        }

        public ICommand CreateSkillCommand { get; }
        private string _skillName;
        private string _goalString;
        private int _goalTime;
        private int _desiredTime;
        private int _countRepet;

        public string SkillName
        {
            get => _skillName;
            set
            {
                _skillName = value;
                OnPropertyChanged(nameof(SkillName));
            }
        }
        public string GoalString
        {
            get => _goalString;
            set
            {
                _goalString = value;
                OnPropertyChanged(nameof(GoalString));
            }
        }
        public int GoalTime
        {
            get => _goalTime;
            set
            {
                if (value > 0)
                {
                    _goalTime = value;
                    OnPropertyChanged(nameof(GoalTime));
                }
            }
        }
        public int DesiredTime
        {
            get => _desiredTime;
            set
            {
                if (value > 0)
                {
                    _desiredTime = value;
                    OnPropertyChanged(nameof(DesiredTime));
                }
            }
        }
        public int CountRepet
        {
            get => _countRepet;
            set
            {
                _countRepet = value;
                OnPropertyChanged(nameof(CountRepet));
            }
        }

        private void CreateSkill()
        {
            Skill skill = new Skill();
            skill.Name = SkillName;
            skill.AllTime = TimeSpan.Zero;
            skill.GoalTime = TimeSpan.FromHours( GoalTime);
            skill.DesiredTime = TimeSpan.FromHours( DesiredTime);
            skill.CountRepet = CountRepet;
            skill.WhatIsGoal = GoalString;
            skill.IsKeepTrack = true;
            skill.ProcentSkill = 0;
            skill.CreateData = DateTime.Now;
            skill.EditDateTime = DateTime.Now;

            DB.SaveSkill(skill);

            var skillsDB = DB.GetSkills();

            var skillFromDB = new Skill();
            if (skillsDB != null)
            {
                foreach (var item in skillsDB)
                {
                    if (item.Name == skill.Name && item.CreateData.Date == DateTime.Now.Date)
                    {
                        skillFromDB = item;
                    }
                }

                TimeWeek timeWeek = new TimeWeek();
                timeWeek.idSkell = skillFromDB.ID;
                timeWeek.DateEdit = DateTime.Now;

                DB.SaveTimeWeek(timeWeek);
            }
            

            CreateSkillEvent?.Invoke();
        }
    }
}
