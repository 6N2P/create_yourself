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
            SkillName = "Создание тест";
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

        private void CreateSkill()
        {
            Skill skill = new Skill();
            skill.Name = SkillName;
            skill.AllTime = TimeSpan.Zero;
            skill.WhatIsGoal = GoalString;
            skill.IsKeepTrack = true;

            DB.SaveSkill(skill);

            CreateSkillEvent?.Invoke();
        }
    }
}
