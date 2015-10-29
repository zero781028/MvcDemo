using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class OrderViewModel
    {
        public string DeliveryID { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public string CustomerID { get; set; }
        public string AttribName { get; set; }
        public string EarNo { get; set; }
        public string JoinMan { get; set; }
    }
}
