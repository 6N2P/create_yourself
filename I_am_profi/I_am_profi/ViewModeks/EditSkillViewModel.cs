using I_am_profi.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace I_am_profi.ViewModeks
{
    public class EditSkillViewModel : BasePropertyChange
    {
        public EditSkillViewModel(Skill selectedSkill)
        { 
            _skill = selectedSkill;
        }

        private Skill _skill;
    }
}
