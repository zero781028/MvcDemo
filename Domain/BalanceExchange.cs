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
    
    public partial class BalanceExchange
    {
        public string MemberID { get; set; }
        public string TXN_SN { get; set; }
        public int SN { get; set; }
        public string Reason { get; set; }
        public string SubReason { get; set; }
        public string ItemID { get; set; }
        public int PointDel { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public string Rank { get; set; }
    }
}
