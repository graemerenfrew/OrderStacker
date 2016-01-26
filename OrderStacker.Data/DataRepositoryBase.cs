using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;

namespace OrderStacker.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, OrderStackerContext>
        where T : class, IIdentifiableEntity, new() 
    {
        //this is kind of a pass-thru class, to save us typing OrderStackContext with every repo
    }
}
