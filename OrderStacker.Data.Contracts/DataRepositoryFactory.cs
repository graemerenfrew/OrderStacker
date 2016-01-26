using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStacker.Data.Contracts
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {

        T IDataRepositoryFactory.GetDataRepository<T>()
        {
           //Go and find me a data repository, as long as T is a repo implmenter
            //Since we know the repositories are available via MEF, we don't
            //have to manually instantiate them
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
