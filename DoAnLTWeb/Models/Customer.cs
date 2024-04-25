using System;
using System.Collections.Generic;

namespace DoAnLTWeb.Models;

public partial class Customer
{
    public int Idcustomer { get; set; }

    public string Username { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? PhoneCustomer { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CitizenIdentificationCode { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? Sex { get; set; }

    public int? IdImages { get; set; }

    public virtual Image? IdImagesNavigation { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual User UsernameNavigation { get; set; } = null!;
}
