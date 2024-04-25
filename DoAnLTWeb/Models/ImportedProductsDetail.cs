using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class ImportedProductsDetail
{
    public int IdimportedProducts { get; set; }

    public int Idproduct { get; set; }

    public int Quantity { get; set; }

    public double InputPrice { get; set; }

    public virtual ImportedProduct IdimportedProductsNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;
}
