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
using I_am_profi.ViewModeks.ForView;

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

        private CreatorSkillForView _creatorSkillsForView;

        private ObservableCollection<SkillForView> skills;
        public ObservableCollection<SkillForView> Skills
        {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }
        private SkillForView _selectedSkill;
        public SkillForView SelectedSkill
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
            _creatorSkillsForView = new CreatorSkillForView();
            ObservableCollection<SkillForView> newSkills = new ObservableCollection<SkillForView>();
            var s = DB.GetSkills();
            if(s != null)
            {
                foreach(var skill in s)
                {
                    var skillFV = _creatorSkillsForView.CreateSkillFV(skill);
                    newSkills.Add(skillFV);
                }
            }
            Skills = newSkills;
        }
        private void DeleteSkill()
        {
            if(SelectedSkill!= null)
            {
                DB.DeleteSkill(SelectedSkill.idSkill);
                DB.DeleteTimeWeek(SelectedSkill.idSkill);
                SelectedSkill = null;
                GetSkills();
            }
        }

    }
}
