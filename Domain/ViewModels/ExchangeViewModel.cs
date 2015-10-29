using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ExchangeViewModel
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string StName { get; set; }
        public string Source { get; set; }
        public int Amount { get; set; }
        public System.DateTime TxnDate { get; set; }
    }
}
