//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivery
    {
        public Delivery()
        {
            this.DeliveryDetails = new HashSet<DeliveryDetails>();
        }
    
        public string DeliveryID { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public string CustomerID { get; set; }
        public string JoinMan { get; set; }
        public string DeliveryType { get; set; }
        public string InvoiceNo { get; set; }
        public int SubTotal { get; set; }
        public int ValueAddTax { get; set; }
        public int Amount { get; set; }
        public string ShipAddress { get; set; }
        public string Comment { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<DeliveryDetails> DeliveryDetails { get; set; }
    }
}
