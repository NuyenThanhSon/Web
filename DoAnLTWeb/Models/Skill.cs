using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string NameSkill { get; set; } = null!;

    public virtual ICollection<SkillDetail> SkillDetails { get; set; } = new List<SkillDetail>();
}
