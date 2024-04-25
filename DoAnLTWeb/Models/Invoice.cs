using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Invoice
{
    public int Idinvoice { get; set; }

    public int Idcustomer { get; set; }

    public int? Idstaff { get; set; }

    public DateOnly DateCreated { get; set; }

    public int Status { get; set; }

    public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; } = new List<DeliveryNote>();

    public virtual Customer IdcustomerNavigation { get; set; } = null!;

    public virtual Staff? IdstaffNavigation { get; set; }

    public virtual ICollection<Invoicedetail> Invoicedetails { get; set; } = new List<Invoicedetail>();
}
