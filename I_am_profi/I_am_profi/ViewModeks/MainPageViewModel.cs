﻿using I_am_profi.Data;
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
        }

        
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
      

        private void GetSkills()
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
     
    }
}