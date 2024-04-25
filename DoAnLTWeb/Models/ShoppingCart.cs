using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class ShoppingCart
{
    public int IdshoppingCart { get; set; }

    public int Idcustomer { get; set; }

    public virtual Customer IdcustomerNavigation { get; set; } = null!;

    public virtual ICollection<ShoppingCartDeltail> ShoppingCartDeltails { get; set; } = new List<ShoppingCartDeltail>();
}
