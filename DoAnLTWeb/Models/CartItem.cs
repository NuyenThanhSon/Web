namespace DoAnLTWeb.Models
{

    [Serializable]
    public class CartItem
    {
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }

        public DeliveryNote DeliveryNote { get; set; }
    }
}
