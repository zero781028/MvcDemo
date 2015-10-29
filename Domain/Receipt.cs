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
    
    public partial class Receipt
    {
        public Receipt()
        {
            this.ReceiptDetails = new HashSet<ReceiptDetails>();
        }
    
        public string ReceiptID { get; set; }
        public System.DateTime ReceiptDate { get; set; }
        public string SupplierID { get; set; }
        public string ReceiptType { get; set; }
        public string InvoiceNo { get; set; }
        public int SubTotal { get; set; }
        public int ValueAddTax { get; set; }
        public int Amount { get; set; }
        public string ShipAddress { get; set; }
        public string Comment { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ReceiptDetails> ReceiptDetails { get; set; }
    }
}