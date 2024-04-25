using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class ShoppingCartDeltail
{
    public int IdshoppingCart { get; set; }

    public int Idproduct { get; set; }

    public int Quantity { get; set; }

    public virtual Product IdproductNavigation { get; set; } = null!;

    public virtual ShoppingCart IdshoppingCartNavigation { get; set; } = null!;
}
