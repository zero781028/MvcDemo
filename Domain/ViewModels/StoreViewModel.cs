using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class StoreViewModel
    {
        public string STNID { get; set; }
        public string STNNAME { get; set; }
        public string DST_FLAG { get; set; }
        public string OPEN_YMD { get; set; }
        public string CLOSE_YMD { get; set; }
        public string DST_YMD { get; set; }        
    }
}
