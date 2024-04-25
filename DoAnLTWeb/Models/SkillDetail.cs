using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class SkillDetail
{
    public int IdSkill { get; set; }

    public int Idstaff { get; set; }

    public DateTime UpdateDay { get; set; }

    public virtual Skill IdSkillNavigation { get; set; } = null!;

    public virtual Staff IdstaffNavigation { get; set; } = null!;
}
