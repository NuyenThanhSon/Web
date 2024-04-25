using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class DeliveryNote
{
    public int IdDeliveryNotes { get; set; }

    public int Idinvoice { get; set; }

    public DateOnly DateCreated { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public string RecipientPhone { get; set; } = null!;

    public int Status { get; set; }

    public int? Idstaff { get; set; }

    public virtual Invoice IdinvoiceNavigation { get; set; } = null!;

    public virtual Staff? IdstaffNavigation { get; set; }
}
