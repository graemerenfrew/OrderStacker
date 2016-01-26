using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using Core.Common.Contracts;

namespace OrderStacker.Data.Contracts.Repository_Interfaces
{
          public interface ITradeRepository : IDataRepository<Trade>
        {
            IEnumerable<Trade> GetAllTradesFilledByUserId(int userId);
        }
 
}
