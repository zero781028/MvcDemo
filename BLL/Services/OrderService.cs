using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repository;
using Domain;
using Domain.ViewModels;
using AutoMapper;
using PagedList;

namespace BLL.Services
{
    public class OrderService
    {
        private IRepository<Delivery> db;
        public OrderService()
        {
            db = new GenericRepository<Delivery>();
        }

        public List<OrderViewModel> Get(out int TotalRow)
        {
            var DbResult=db.Get().ToList();
            TotalRow = DbResult.Count;

            Mapper.CreateMap<Delivery, OrderViewModel>()
                .ForMember(o => o.AttribName, x => x.MapFrom(c => c.Customer.AttribName))
                .ForMember(o => o.EarNo, x => x.MapFrom(c => c.Customer.EarNo))
                .ForMember(o => o.JoinMan, x => x.MapFrom(c => c.Customer.JoinMan));

            return Mapper.Map<List<Delivery>, List<OrderViewModel>>(DbResult)
                .OrderBy(o => o.DeliveryDate).ToList();
        }

        

        public IEnumerable<OrderViewModel> Get(int CurrentPage, int PageSize, out int TotalRow)
        {            
            var DbResult = db.Get();
            DbResult = DbResult.OrderBy(o => o.DeliveryDate);
            TotalRow = DbResult.Count();
            DbResult = DbResult.ToPagedList(CurrentPage, PageSize);
            Mapper.CreateMap<Delivery, OrderViewModel>()
                .ForMember(o => o.AttribName, x => x.MapFrom(c => c.Customer.AttribName))
                .ForMember(o => o.EarNo, x => x.MapFrom(c => c.Customer.EarNo))
                .ForMember(o => o.JoinMan, x => x.MapFrom(c => c.Customer.JoinMan));

            return Mapper.Map<IEnumerable<Delivery>, IEnumerable<OrderViewModel>>(DbResult);
        }
    }
}
