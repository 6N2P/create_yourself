using I_am_profi.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace I_am_profi.ViewModeks.ForView
{
    public class CreatorSkillForView
    {
        public SkillForView CreateSkillFV(Skill skill)
        {
            SkillForView skillFV = new SkillForView();

            skillFV.idSkill = skill.ID;
            skillFV.Name = skill.Name;
            skillFV.AllTime = skill.AllTime;
            skillFV.GoalTime = skill.GoalTime;
            skillFV.DesiredTime = skill.DesiredTime;
            skillFV.CountRepet = skill.CountRepet;
            skillFV.CountRepetNaw = skill.CountRepetNaw;
            skillFV.WhatIsGoal = skill.WhatIsGoal;
            skillFV.IsKeepTrack = skill.IsKeepTrack;
            skillFV.ProcentSkill = skill.ProcentSkill;
            skillFV.SkillLevel = GetSkillLeval(skill.AllTime);

            return skillFV;
        }

        private string GetSkillLeval (TimeSpan allTaim)
        {
            string result = string.Empty;
            int days = allTaim.Days;
            int hours = allTaim.Hours;
            int allHours = days * 24 + hours;

            if(allHours >= 0 && allHours < 50)
            {
                return result = "Новичек";
            }
            else
            {
                if(allHours >= 50 &&  allHours < 200) 
                {
                    return result = "Ознакомлен";
                }
            }
            return result = "Пока не придумал";
        }
    }
}
