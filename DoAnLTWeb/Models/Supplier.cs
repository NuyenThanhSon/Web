using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Supplier
{
    public int Idsupplier { get; set; }

    public string SupplierName { get; set; } = null!;

    public string PhoneSupplier { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;

    public string? EmailSupplier { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
