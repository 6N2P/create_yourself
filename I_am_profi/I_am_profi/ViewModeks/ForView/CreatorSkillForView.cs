﻿using I_am_profi.Data;
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
            skillFV.CreateData = skill.CreateData;
            skillFV.EditDateTime = skill.EditDateTime;

            return skillFV;
        }

        private string GetSkillLeval (TimeSpan allTaim)
        {
            //40 часов стандартная неделя
            //160 часов в месяце
            //160*12=1920 год
            string result = string.Empty;
            int days = allTaim.Days;
            int hours = allTaim.Hours;
            int allHours = days * 24 + hours;

            if(allHours >= 0 && allHours < 160*8)
            {
                return result = "Новичек";
            }
            else
            {
                if(allHours >= 240 &&  allHours < 160 * 18) 
                {
                    return result = "Ознакомлен";
                }
            }
            return result = "Пока не придумал";
        }
    }
}
