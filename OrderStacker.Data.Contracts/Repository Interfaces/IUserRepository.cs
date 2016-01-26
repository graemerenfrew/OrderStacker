using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using Core.Common.Contracts;

//This is needed so we can then export the actual concrete repository through MEF

namespace OrderStacker.Data.Contracts.Repository_Interfaces
{
    public interface IUserRepository : IDataRepository<User>
    {
        //just declare the extra member we added to GetByLogin
        User GetByLogin(string login);
    }
}
