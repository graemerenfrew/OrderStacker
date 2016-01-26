using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IDataRepositoryFactory
    {
        //Get Me a data repository of some type
        T GetDataRepository<T>() where T : IDataRepository;
    }
}
