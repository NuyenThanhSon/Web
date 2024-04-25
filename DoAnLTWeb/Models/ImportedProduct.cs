using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class ImportedProduct
{
    public int IdimportedProducts { get; set; }

    public int Idstaff { get; set; }

    public int Idwarehouse { get; set; }

    public DateOnly DateCreated { get; set; }

    public virtual Staff IdstaffNavigation { get; set; } = null!;

    public virtual Warehouse IdwarehouseNavigation { get; set; } = null!;

    public virtual ICollection<ImportedProductsDetail> ImportedProductsDetails { get; set; } = new List<ImportedProductsDetail>();
}
