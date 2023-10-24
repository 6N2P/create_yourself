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
        }

        public List<Skill> GetSkills()
        {
            return conn.Table<Skill>().ToList();
        }

        public int SaveSkill(Skill skill)
        {
            return conn.Insert(skill);
        }
        public void DeleteSkill(Skill skill)
        { 
             conn.Delete(skill);
        }
    }
}
