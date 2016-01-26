using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using Core.Common.Contracts;

namespace OrderStacker.Data.Contracts.Repository_Interfaces
{
    public interface IOrderRepository : IDataRepository<Order>
    {
        IEnumerable<Order> GetAllEnteredByUserId(int userId);
        IEnumerable<Order> GetAllUnfilledOrders();

        IEnumerable<Order> GetAllOrders();
    }
}
