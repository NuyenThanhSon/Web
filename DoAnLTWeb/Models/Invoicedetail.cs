using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Invoicedetail
{
    public int Idinvoice { get; set; }

    public int Idproduct { get; set; }

    public int TotalQuantity { get; set; }

    public decimal Price { get; set; }

    public virtual Invoice IdinvoiceNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;
}
