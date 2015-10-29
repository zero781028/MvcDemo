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
    public class MemberService
    {
        private ICosmedRepository<Members> db;
        public MemberService()
        {
            db = new CosmedRepository<Members>();
        }

        public List<MemberViewModel> GetMemberList()
        {
            var DbResult = db.Get().ToList();
            Mapper.CreateMap<Members, MemberViewModel>();
            return Mapper.Map<List<Members>, List<MemberViewModel>>(DbResult);
        }

        public MemberViewModel GetMemberInfo(string MemberID)
        {
            var DbResult = db.GetByID(MemberID);
            Mapper.CreateMap<Members, MemberViewModel>();
            return Mapper.Map<Members, MemberViewModel>(DbResult);
        }
    }
}
