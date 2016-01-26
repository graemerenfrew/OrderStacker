using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;
using OrderStacker.Business.Common;
using System.ComponentModel.Composition;
using Core.Common.Contracts;
using Core.Common.Core;
using System.Runtime.Serialization;


namespace OrderStacker.Business.Business_Engines
{
    [Export(typeof(IOrderStackerEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrderStackerEngine : IOrderStackerEngine 
    {
        public bool DoesOrderHaveAssociatedTrades(int orderId, IEnumerable<Trade> trades)
        {
            bool hasTrades = true;

            Trade trade = trades.Where(item => item.OrderId == orderId).FirstOrDefault();
            if (trade != null)
            {
                hasTrades = true;
            }
            else
            {
                hasTrades = false;
            }

            return hasTrades;
        }
    }
}
