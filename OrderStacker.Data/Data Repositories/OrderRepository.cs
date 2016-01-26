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
    public class OrderRepository : DataRepositoryBase<Order>, IOrderRepository
    {
        protected override Order AddEntity(OrderStackerContext entityContext, Order entity)
        {
            return entityContext.OrderSet.Add(entity);
        }

        protected override Order UpdateEntity(OrderStackerContext entityContext, Order entity)
        {
            return (from e in entityContext.OrderSet
                    where e.OrderId == entity.OrderId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Order> GetEntities(OrderStackerContext entityContext)
        {
            return from e in entityContext.OrderSet
                   select e;
        }

        protected override Order GetEntity(OrderStackerContext entityContext, int id)
        {
            var query = (from e in entityContext.OrderSet
                         where e.OrderId == id
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

        public IEnumerable<Order> GetAllOrders()
        {
            using (OrderStackerContext entityContext = new OrderStackerContext())
            {
                return from order in entityContext.OrderSet
                       select order;
            }
        }
        public IEnumerable<Order> GetAllUnfilledOrders()
        {
            using (OrderStackerContext entityContext = new OrderStackerContext())
            {
                var unfilledStatusId = new[] { 1, 3 };

                return from order in entityContext.OrderSet
                                     where order.OrderStatusId.Equals(unfilledStatusId)
                                     select order;
 
            }
        }

        //public IEnumerable<UserOrderInfo> GetCurrentUserOrderInfo()
        //{
        //    using (OrderStackerContext entityContext = new OrderStackerContext())
        //    {
        //        var query = from o in entityContext.OrderSet
        //                    where o.EntityId == 1 //TODO
        //                    join a in entityContext.AccountSet on o.AccountId equals a.AccountId
        //                    join u in entityContext.UserSet on u.UserId equals o.EnteredByUserId
        //                    select new UserOrderInfo()
        //                    {
        //                        User = u,
        //                        Order = o,
        //                        Account = a
        //                    };

        //        //Do a ToList then a ToArray to overcome lazy loading 
        //        //and allow me to get rid of the dbcontext, rather than keep it open
        //        return query.ToFullyLoaded();
                             

        //    }
        //}
    }
}

 