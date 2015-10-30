﻿using System;
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
    public class MemberExchangeService
    {
        internal COSMEDEntities db;
        public MemberExchangeService()
        {
            db = new COSMEDEntities();
        }

        /// <summary>
        /// 查詢日期區間的全部兌換明細
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalRow"></param>
        /// <param name="stdt"></param>
        /// <param name="eddt"></param>
        /// <returns></returns>
        public List<ExchangeViewModel> Get(int CurrentPage, int PageSize, out int TotalRow, string stdt, string eddt)
        {
            var result = GetData(CurrentPage, PageSize,out TotalRow, stdt, eddt, "");
            return result;
        }

        /// <summary>
        /// 查詢日期區間會員卡號的兌換明細
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalRow"></param>
        /// <param name="stdt"></param>
        /// <param name="eddt"></param>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public List<ExchangeViewModel> Get(int CurrentPage,int PageSize, out int TotalRow,string stdt,string eddt,string MemberID)
        {
            var result = GetData(CurrentPage, PageSize, out TotalRow, stdt, eddt, MemberID);
            return result;
        }


        private List<ExchangeViewModel> GetData(int CurrentPage, int PageSize, out int TotalRow, string stdt, string eddt, string MemberID)
        {
            List<ExchangeViewModel> ls = new List<ExchangeViewModel>();
            ExchangeViewModel model;
            DateTime stdate, eddate;
            var list = new List<String>() { "1", "2" };

            stdate = Convert.ToDateTime(stdt);
            eddate = Convert.ToDateTime(eddt);
            var query = (from A in db.BalanceTxnHist
                         join B in db.BalanceExchange on new { a = A.MemberID, b = A.TXN_SN } equals new { a = B.MemberID, b = B.TXN_SN }
                         join M in db.Members on A.MemberID equals M.MemberID
                         join C in db.TENPO on A.Source equals C.STNID
                         where A.TxnDate >= stdate && A.TxnDate <= eddate
                         where list.Contains(B.SubReason)                  
                         select new
                         {
                             Member = A.MemberID,
                             Txn_SN=A.TXN_SN,
                             TxnDate = A.TxnDate,
                             Amount = A.Amount_del,
                             Name = M.Name,
                             Rank = M.Rank,
                             Source = A.Source,
                             StName = C.STNNAME
                         }).AsEnumerable();

            if (!String.IsNullOrEmpty(MemberID))
            {
                query = query.Where(o => o.Member == MemberID);
            }
            query = query.OrderBy(o => o.TxnDate);

            TotalRow = query.Count();
            query = query.ToPagedList(CurrentPage, PageSize);

            foreach (var item in query)
            {
                model = new ExchangeViewModel()
                {
                    MemberID = item.Member,
                    Txn_SN=item.Txn_SN,
                    TxnDate = item.TxnDate,
                    Amount = item.Amount,
                    Rank = item.Rank,
                    StName = item.StName,
                    Name = item.Name,
                    Source = item.Source                   
                };
                ls.Add(model);
            }

            return ls;
        }

        /// <summary>
        /// 查詢日期區間的商品兌換統計
        /// </summary>
        /// <param name="STNID">門市編號</param>
        /// <param name="stdate">起始日期</param>
        /// <param name="eddate">結束日期</param>
        /// <returns></returns>
        public List<ProductExchangeViewModel> GetProductExchangeList(string STNID, string stdate, string eddate)
        {
            DateTime stdt = Convert.ToDateTime(stdate);
            DateTime eddt = Convert.ToDateTime(eddate);
            var list = new List<string>() { "1", "2" };
            var ls = new List<ProductExchangeViewModel>();

            var query1 =
            (from A in db.BalanceTxnHist
             join B in db.BalanceExchange on new { a = A.MemberID, b = A.TXN_SN } equals new { a = B.MemberID, b = B.TXN_SN }
             where (A.TxnDate >= stdt && A.TxnDate <= eddt)
             where list.Contains(B.SubReason)
             select new
             {
                 A.Source,
                 A.MemberID,
                 B.ItemID,
                 B.Qty,
                 B.PointDel
             }).ToList();

            if (!String.IsNullOrEmpty(STNID)) query1 = query1.Where(q => q.Source == STNID).ToList();

            var query2 = (from item in db.ITEM_DEF select new { ItemID = item.ITEM_BAR, ItemName = item.SNAME }).ToList();

            var finalQuery =
            (from a in query1
             group a by a.ItemID into pg
             join b in query2 on pg.FirstOrDefault().ItemID equals b.ItemID
             select new
             {
                 ItemID = pg.Key,
                 ItemName = b.ItemName,
                 TotalQty = pg.Sum(m => m.Qty),
                 TotalPoint = pg.Sum(m => m.PointDel)
             }).ToList();

            foreach (var item in finalQuery)
            {
                var model = new ProductExchangeViewModel()
                {
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    TotalPoint = item.TotalPoint,
                    TotalQty = item.TotalQty
                };
                ls.Add(model);
            }

            return ls;
        }
    }
}
