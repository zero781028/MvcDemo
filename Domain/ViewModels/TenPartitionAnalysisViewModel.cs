using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class TenPartitionAnalysisViewModel
    {
        public long Price { get; set; }
        public double TTotalPrice { get; set; }
        public double TTotalCnt { get; set; }
        public double TTotalQty { get; set; }
    }
}
