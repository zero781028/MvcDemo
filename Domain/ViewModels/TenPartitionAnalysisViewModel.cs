using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class TenPartitionAnalysisViewModel
    {
        public int Price { get; set; }
        public float TTotalPrice { get; set; }
        public float TTotalCnt { get; set; }
        public float TTotalQty { get; set; }
    }
}
