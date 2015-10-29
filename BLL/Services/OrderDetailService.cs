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

namespace BLL.Services
{
    public class OrderDetailService
    {
        private IRepository<DeliveryDetails> db;
        public OrderDetailService()
        {
            db = new GenericRepository<DeliveryDetails>();
        }

        public List<OrderDetailViewModel> GetDetail(string DeliverID,out int TotalRow)
        {
            var DbResult = db.Get().Where(o => o.DeliveryID == DeliverID).ToList();
            TotalRow = DbResult.Count;

            Mapper.CreateMap<DeliveryDetails, OrderDetailViewModel>()
                .ForMember(o => o.ProductName, x => x.MapFrom(p => p.Product.ProductName));

            return Mapper.Map<List<DeliveryDetails>, List<OrderDetailViewModel>>(DbResult);

        }
    }
}
