using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace I_am_profi.Data
{
    public class DB
    {
        private readonly SQLiteConnection conn;

        public DB(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Skill>();
            conn.CreateTable<Revard>();
            conn.CreateTable<Reminder>();
            conn.CreateTable<UserTime>();
        }

        #region Skell
        public List<Skill> GetSkills()
        {
            return conn.Table<Skill>().ToList();
        }
        public Skill GetSkill(int idSkill)
        {
            var skillDB = conn.Table<Skill>().ToList();

            Skill skill = new Skill();
            if (skillDB.Count > 0)
            {
                foreach(var s in skillDB)
                {
                    if(s.ID == idSkill) return s;
                }
            }
            
            
            return skill;
        }

        public void ChangeTimeAlltSkill(Skill skill)
        {
            conn.Update(skill);
        }
        public int SaveSkill(Skill skill)
        {
            return conn.Insert(skill);
        }
        
        public void DeleteSkill(Skill skill)
        {
            conn.Delete(skill);
        }
        public void DeleteSkill(int skillId)
        {
            var skillDB = conn.Table<Skill>().ToList();

            Skill skill = new Skill();
            if (skillDB.Count > 0)
            {
                foreach (var s in skillDB)
                {
                    if (s.ID == skillId) conn.Delete(s);
                }
            }            
        }
        #endregion

        #region Revard
        public List<Revard> GetRevard()
        {
            return conn.Table<Revard>().ToList();
        }
        public int SaveRevard(Revard revard)
        {
            return conn.Insert(revard);
        }
        public void DeleteRevard(Revard revard)
        {
            conn.Delete(revard);
        }
        #endregion

        #region Reminder
        public List<Reminder> GetReminders()
        {
            return conn.Table<Reminder>().ToList();
        }
        public int SaveReminder(Reminder reminder)
        {
            return conn.Insert(reminder);
        }
        public void DeleteReminder(Reminder reminder)
        {
            conn.Delete(reminder);
        }
        #endregion

        #region UserName
        public List<UserTime> GetUserTimes()
        {
            return conn.Table<UserTime>().ToList();
        }
        public int SaveUserTime(UserTime userTime)
        {
            return conn.Insert(userTime);
        }
        public void DeleteUserTime(UserTime userTime)
        {
            conn.Delete(userTime);
        } 
        #endregion
    }
}
