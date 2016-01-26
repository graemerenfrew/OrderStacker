using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using OrderStacker.Business.Entities;
using Core.Common.Core;
using Core.Common.Exceptions;

namespace OrderStacker.Business.Contracts 
{
    [ServiceContract]
    public interface IInventoryService  //Order Inventory  
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]  //We have to tell the service of other types it'll need to serialize to pass up the stack
        Order GetOrder(int orderId);

        [OperationBehavior]
        Order[] GetAllOrders();

        [OperationBehavior]
        Order[] GetAllUnfilledOrders();

        [OperationBehavior]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Order EditOrder(Order order);

        [OperationBehavior]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteOrder(int orderId); //Should we not just cancel? TODO

        [OperationBehavior]
        Order[] GetOrdersForStacking(int commodityId, int orderTypeId, float variance);  //This will return orders with information on where they will be in the stack

    }
}
