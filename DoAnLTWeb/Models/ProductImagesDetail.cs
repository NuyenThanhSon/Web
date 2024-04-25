using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class ProductImagesDetail
{
    public int Idimages { get; set; }

    public int Idproduct { get; set; }

    public DateOnly? Ngaycapnhat { get; set; }

    public virtual Image IdimagesNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;
}
