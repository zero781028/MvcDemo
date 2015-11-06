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
    }
}
