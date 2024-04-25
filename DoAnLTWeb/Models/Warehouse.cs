using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Warehouse
{
    public int Idwarehouse { get; set; }

    public string WarehouseName { get; set; } = null!;

    public string WarehouseAddress { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public virtual ICollection<ImportedProduct> ImportedProducts { get; set; } = new List<ImportedProduct>();

    public virtual ICollection<Warehousedetail> Warehousedetails { get; set; } = new List<Warehousedetail>();
}
