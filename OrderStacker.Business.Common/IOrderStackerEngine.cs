using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;
using System.Runtime.Serialization;

namespace OrderStacker.Business.Common
{
    public interface IOrderStackerEngine
    {
        bool DoesOrderHaveAssociatedTrades(int orderId, System.Collections.Generic.IEnumerable<OrderStacker.Business.Entities.Trade> trades);
    }
}
