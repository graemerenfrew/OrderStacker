using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using OrderStacker.Data.Contracts.Repository_Interfaces;
using System.ComponentModel.Composition;

namespace OrderStacker.Data.Data_Repositories
{
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(OrderStackerContext entityContext, Account entity)
        {
            return entityContext.AccountSet.Add(entity);
        }

        protected override Account UpdateEntity(OrderStackerContext entityContext, Account entity)
        {
            return (from e in entityContext.AccountSet
                    where e.AccountId == entity.AccountId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Account> GetEntities(OrderStackerContext entityContext)
        {
            return from e in entityContext.AccountSet
                   select e;
        }

        protected override Account GetEntity(OrderStackerContext entityContext, int id)
        {
            var query = (from e in entityContext.AccountSet
                         where e.AccountId == id
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }

        public Account GetByShortCode(string ShortCode)
        {
            using (OrderStackerContext entityContext = new OrderStackerContext())
            {
                return (from a in entityContext.AccountSet
                        where a.ShortCode == ShortCode
                        select a).FirstOrDefault();
            }
        }
    }
}
