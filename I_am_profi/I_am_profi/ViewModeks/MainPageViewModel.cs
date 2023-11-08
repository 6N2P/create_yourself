using I_am_profi.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Windows.Input;
using I_am_profi.Pages;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace I_am_profi.ViewModeks
{
    public class MainPageViewModel : BasePropertyChange
    {
        
        public MainPageViewModel()
        {
            GetSkills();
            DeleteSkillCommand = new Command(DeleteSkill);
            DateDay = DateTime.Now.ToString("dd");
            Month = DateTime.Now.ToString("MMMM").ToUpper();
            DayYear = DateTime.Now.DayOfYear;
            DayOfWeek = DateTime.Now.ToString("dddd").ToUpper();
        }

      

        public ICommand DeleteSkillCommand { get; }
        private static DB dB;
        public static DB DB
        {
            get
            {
                
                if (dB is null) dB = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"skillDB.sqlite3"));
                return dB;
            }
        }

        private ObservableCollection<Skill> skills;
        public ObservableCollection<Skill> Skills
        {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }
        private Skill _selectedSkill;
        public Skill SelectedSkill
        {
            get => _selectedSkill;
            set
            {
                _selectedSkill = value;
                OnPropertyChanged(nameof(SelectedSkill));
            }
        }
        private string _dateDay;
        public string DateDay
        {
            get=> _dateDay;
            set
            {
                _dateDay = value;
                OnPropertyChanged(nameof(DateDay));
            }
        }
        private string _month;
        public string Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged(nameof(Month));
            }
        }

        private int _deyYear;
        public int DayYear
        {
            get => _deyYear;
            set
            {
                _deyYear = value;
                OnPropertyChanged(nameof(DayYear));
            }
        }

        private string _dayOfweek;
        public string DayOfWeek
        {
            get => _dayOfweek;
            set
            {
                _dayOfweek = value;
                OnPropertyChanged(nameof(DayOfWeek));
            }
        }

        public void GetSkills()
        {
            ObservableCollection<Skill> newSkills = new ObservableCollection<Skill>();
            var s = DB.GetSkills();
            if(s != null)
            {
                foreach(var skill in s)
                {
                    newSkills.Add(skill);
                }
            }
            Skills = newSkills;
        }
        private void DeleteSkill()
        {
            if(SelectedSkill!= null)
            {
                DB.DeleteSkill(SelectedSkill);
                SelectedSkill = null;
                GetSkills();
            }
        }

    }
}
