using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using Core.Common.Data;
using OrderStacker.Data.Contracts.Repository_Interfaces;
using System.ComponentModel.Composition;

namespace OrderStacker.Data.Data_Repositories
{
    [Export(typeof(IUserRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRepository : DataRepositoryBase<User>, IUserRepository
    {
        protected override User AddEntity(OrderStackerContext entityContext, User entity)
        {
            return entityContext.UserSet.Add(entity);
        }

        protected override User UpdateEntity(OrderStackerContext entityContext, User entity)
        {
            return (from e in entityContext.UserSet
                    where e.UserId == entity.UserId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<User> GetEntities(OrderStackerContext entityContext)
        {
            return from e in entityContext.UserSet
                   select e;
        }

        protected override User GetEntity(OrderStackerContext entityContext, int id)
        {
            var query = (from e in entityContext.UserSet
                         where e.UserId == id
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }

        public User GetByLogin(string login)
        {
            using (OrderStackerContext entityContext = new OrderStackerContext())
            {
                return (from a in entityContext.UserSet
                            where a.LoginEmail == login
                            select a).FirstOrDefault();
            }
        }
    }
}
