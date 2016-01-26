using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using OrderStacker.Data.Contracts.Repository_Interfaces;
using System.ComponentModel.Composition;
using OrderStacker.Data.Contracts;
using Core.Common.Extensions;

namespace OrderStacker.Data.Data_Repositories
{
    [Export(typeof(IOrderRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class TradeRepository : DataRepositoryBase<Trade>, ITradeRepository
    {
        protected override Trade AddEntity(OrderStackerContext entityContext, Trade entity)
        {
            return entityContext.TradeSet.Add(entity);
        }

        protected override Trade UpdateEntity(OrderStackerContext entityContext, Trade entity)
        {
            return (from e in entityContext.TradeSet
                    where e.TradeId == entity.TradeId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Trade> GetEntities(OrderStackerContext entityContext)
        {
            return from e in entityContext.TradeSet
                   select e;
        }

        protected override Trade GetEntity(OrderStackerContext entityContext, int id)
        {
            var query = (from e in entityContext.TradeSet
                         where e.TradeId == id
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }



        public IEnumerable<Order> GetAllEnteredByUserId(int userId)
        {
            using (OrderStackerContext entityContext = new OrderStackerContext())
            {
                return from e in entityContext.OrderSet
                       where e.EnteredByUserId == userId
                       select e;
            }
        }


        public IEnumerable<Trade> GetAllTradesFilledByUserId(int userId)
        {
            using (OrderStackerContext entityContext = new OrderStackerContext())
            {
                return from e in entityContext.TradeSet
                       where e.FilledByUserId == userId
                       select e;
            }
        }

       
    }
}
