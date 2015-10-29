using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProductExchangeViewModel
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public int TotalQty { get; set; }
        public int TotalPoint { get; set; }
    }
}
