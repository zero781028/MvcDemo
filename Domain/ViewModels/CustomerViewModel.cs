using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CustomerViewModel
    {
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
    }
}
