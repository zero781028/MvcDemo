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
    
    public partial class Customer
    {
        public Customer()
        {
            this.Delivery = new HashSet<Delivery>();
        }
    
        public string CustomerID { get; set; }
        public string AttribName { get; set; }
        public string CompanyName { get; set; }
        public string EarNo { get; set; }
        public string JoinMan { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string MobilePhone { get; set; }
        public string CompanyAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public Nullable<System.DateTime> LastDeliveryDate { get; set; }
        public string Comment { get; set; }
    
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
