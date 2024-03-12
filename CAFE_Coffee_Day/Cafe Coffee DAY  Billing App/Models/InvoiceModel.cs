using CCD_EnitityLayer;

namespace Cafe_Coffee_DAY__Billing_App.Models
{
    public class InvoiceModel
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string CustName { get; set; }
        public int OrderID { get; set; }
        public string Itemname { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
