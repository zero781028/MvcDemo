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
    
    public partial class Transfer
    {
        public Transfer()
        {
            this.TransferDetails = new HashSet<TransferDetails>();
        }
    
        public string TransferID { get; set; }
        public System.DateTime TransferDate { get; set; }
        public string TransferType { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
    
        public virtual ICollection<TransferDetails> TransferDetails { get; set; }
    }
}
