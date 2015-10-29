using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class OrderDetailViewModel
    {
        public string DeliveryID { get; set; }
        public byte DeliverySeq { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
    }
}
