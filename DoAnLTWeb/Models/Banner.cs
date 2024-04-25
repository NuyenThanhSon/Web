using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Banner
{
    public int IdBanner { get; set; }

    public double Horizontal { get; set; }

    public double Vertical { get; set; }

    public int Idimages { get; set; }

    public virtual Image IdimagesNavigation { get; set; } = null!;
}
