using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ExchangeDetailViewModel
    {
        public string MemberID { get; set; }
        public string Txn_SN { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public int SN { get; set; }
        public string Reason { get; set; }
        public string Rank { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
