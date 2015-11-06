using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.ViewModels;

namespace BLL.Services
{
    public class TenPartitionService
    {
        internal COSMED_CRMEntities db;
        public TenPartitionService()
        {
            db = new COSMED_CRMEntities();
        }

        /// <summary>
        /// 十等份分析表
        /// </summary>
        /// <returns></returns>
        public List<TenPartitionAnalysisViewModel> GetTenPartitionAnalysis()
        {
            DateTime st = Convert.ToDateTime("2015/07/01");
            DateTime ed = Convert.ToDateTime("2015/07/31");
            int s = 1;

            var query1 = (from A in db.STA_DAILY_ITEM_CTGRY_MBR_E
                         where Convert.ToDateTime(A.TRAN_DATE) >= st && Convert.ToDateTime(A.TRAN_DATE) <= ed
                         group A by A.MBR_ID into grp
                         select new
                         {
                             MBR_ID=grp.Key,
                             Price=grp.Sum(p=>p.PURCHASE_PRICE),
                             Cnt=grp.Sum(c=>c.PURCHASE_CNT),
                             Qty=grp.Sum(q=>q.PURCHASE_QTY)
                         }).OrderBy(o=>-o.Price).ToList();

            var query2 = from q in query1
                         select new
                         {
                             sn=s++,
                             Price=q.Price,
                             Cnt=q.Cnt,
                             Qty=q.Qty
                         };
            int divided = query2.Count() / 10;
            var TotalPurchase = query2.Sum(p => p.Price);
            var ls = new List<TenPartitionAnalysisViewModel>();

            for (int i = 1; i <=10; i++)
            {
                var result = query2.Skip((i - 1) * divided).Take(divided).ToList();
                TenPartitionAnalysisViewModel model = new TenPartitionAnalysisViewModel()
                {
                    Price=Convert.ToInt64(result.Sum(p=>p.Price)),
                    TTotalPrice=Convert.ToDouble(result.Sum(p=>p.Price))/Convert.ToDouble(TotalPurchase),
                    TTotalCnt=Convert.ToDouble(result.Sum(c=>c.Cnt)/divided),
                    TTotalQty=Convert.ToDouble(result.Sum(q=>q.Qty)/divided)
                };
                ls.Add(model);
            }

            return ls;
        }
    }
}
