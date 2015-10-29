using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.ViewModels;
using DAL.Interfaces;
using DAL.Repository;
using AutoMapper;

namespace BLL.Services
{    
    public class StoreService
    {
        private ICosmedRepository<TENPO> db;
        public StoreService()
        {
            db = new CosmedRepository<TENPO>();
        }

        public List<StoreViewModel> GetStoreList()
        {
            var DbResult = db.Get().Where(s => s.CLOSE_YMD != null).ToList();
            Mapper.CreateMap<TENPO, StoreViewModel>()
                .ForMember(s=>s.STNNAME,x=>x.MapFrom(d=>string.Format("{0} {1}",d.STNID,d.STNNAME)));
            return Mapper.Map<List<TENPO>, List<StoreViewModel>>(DbResult);
        }

        public StoreViewModel GetStoreInfo(string STNID)
        {
            var DbResult = db.GetByID(STNID);
            Mapper.CreateMap<TENPO, StoreViewModel>();
            return Mapper.Map<TENPO, StoreViewModel>(DbResult);
        }
    }
}
