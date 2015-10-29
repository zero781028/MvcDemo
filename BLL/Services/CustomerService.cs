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
    public class CustomerService
    {
        private IRepository<Customer> db;
        public CustomerService()
        {
            db = new GenericRepository<Customer>();
        }

        public List<CustomerViewModel> Get()
        {
            var DbResult = db.Get().ToList();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            return Mapper.Map<List<Customer>, List<CustomerViewModel>>(DbResult);
        }

        //public IQueryable<CustomerViewModel> Get(int CurrentPage, int PageSize, out int TotalRow)
        //{
        //    TotalRow = db.Get().ToList().Count;            
        //    var DbResult = db.Get().ToList().Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        //    Mapper.CreateMap<Customer, CustomerViewModel>();
        //    return Mapper.Map<List<Customer>, List<CustomerViewModel>>(DbResult).AsQueryable();
        //}

        public IEnumerable<CustomerViewModel> Get(int CurrentPage, int PageSize, out int TotalRow)
        {
            var DbResult = db.Get();
            DbResult = DbResult.OrderBy(o => o.CustomerID);
            TotalRow = DbResult.Count();
            DbResult = DbResult.ToPagedList(CurrentPage, PageSize);

            Mapper.CreateMap<Customer, CustomerViewModel>();
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(DbResult);
        }

        public CustomerViewModel Get(string CustomerID)
        {
            var DbResult = db.Get().Where(c => c.CustomerID.Trim() == CustomerID.Trim()).FirstOrDefault();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            return Mapper.Map<Customer, CustomerViewModel>(DbResult);
        }

        public void AddCustomer(CustomerViewModel model)
        {
            Mapper.CreateMap<CustomerViewModel, Customer>();
            var cust = Mapper.Map<CustomerViewModel, Customer>(model);
            db.Insert(cust);
        }

        public void SaveCustomer(CustomerViewModel model)
        {
            Mapper.CreateMap<CustomerViewModel, Customer>();
            var cust = Mapper.Map<CustomerViewModel, Customer>(model);
            db.Update(cust);
        }

        public void DeleteCustomer(string CustomerID)
        {
            var customer = db.GetByID(CustomerID);
            db.Delete(customer);
        }
    }
}
