using System;
using Core.Common.Contracts;
using Core.Common.Core;  //So we can use objectbase
using System.ComponentModel.Composition;
using OrderStacker.Business.Contracts;
using OrderStacker.Data.Contracts;
using OrderStacker.Business.Entities;
using OrderStacker.Data.Contracts.Repository_Interfaces;  //so we can use IOrderRepostiroy
using Core.Common.Exceptions; //so we can have our own exception classes
using System.ServiceModel;
using System.Collections.Generic; //so we can use WCF FaultException
using System.Runtime.Serialization;
using System.Linq;

namespace OrderStacker.Business.Managers 
{
    //By default, services are PerSession, which isn't very scalable, so let's make it PerCall
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)] //false, because combo of PerCall and Multiple effectively make it so
    //Set concurrency to multiple, so we can process multiple calls at the same time
    public class InventoryManager : ManagerBase, IInventoryService
    {
        public InventoryManager()
        {

        }

        //for testing purposes, I'l want to inject my own repo factory
        public InventoryManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }
        [Import] //for mef
        IDataRepositoryFactory _DataRepositoryFactory;


        //Get my Order repo from the data repository factory
        public OrderStacker.Business.Entities.Order GetOrder(int orderId)
        {
            //Using this Pattern of sending codesnippets into the ExecuteFaultHandledOperation
            //means that my GENERAL error handling is in only one place
            return ExecuteFaultHandledOperation(() =>
               {
                   IOrderRepository orderRepository = _DataRepositoryFactory.GetDataRepository<IOrderRepository>();

                   Order orderEntity = orderRepository.Get(orderId);
                   if (orderEntity == null)
                   {
                       NotFoundException ex = new NotFoundException(string.Format("Order with Id of {0} was not found", orderId));

                       //Because this fault is in WCF, we have to throw a SOAP fault up the client
                       throw new FaultException<NotFoundException>(ex, ex.Message); //throwing this will not break the proxy either
                   }
                   return orderEntity;
               }
           );

         
        }

        public OrderStacker.Business.Entities.Order[] GetAllOrders()
        {
            return ExecuteFaultHandledOperation( () =>
                { 
                IOrderRepository orderRepository = _DataRepositoryFactory.GetDataRepository<IOrderRepository>();
             
                IEnumerable<Order> orders = orderRepository.GetAllOrders();  //this should be GetUnfilledOrders
               
                return orders.ToArray();
                });
        
        }

        public OrderStacker.Business.Entities.Order[] GetAllUnfilledOrders()
        {

           return ExecuteFaultHandledOperation( () => 
               { 
                IOrderRepository orderRepository = _DataRepositoryFactory.GetDataRepository<IOrderRepository>();
                IEnumerable<Order> orders = orderRepository.GetAllUnfilledOrders();  //this should be GetUnfilledOrders
                  
                return orders.ToArray();
               }); 
        }

        [OperationBehavior(TransactionScopeRequired=true)] //now we're transaction friendly. If an existing transaction exists, this method will vote on it. If no existing trans, this method will create a new transaction
        public OrderStacker.Business.Entities.Order EditOrder(Order order)
        {

            return ExecuteFaultHandledOperation(() =>
            {
                IOrderRepository orderRepository = _DataRepositoryFactory.GetDataRepository<IOrderRepository>();

                Order updatedEntity = null;
                if (order.OrderId == 0)
                {
                    updatedEntity = orderRepository.Add(order); //create if it didn't exist
                }
                else
                {
                    updatedEntity = orderRepository.Update(order);
                }

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)] //now we're transaction friendly. If an existing transaction exists, this method will vote on it. If no existing trans, this method will create a new transaction
        public void DeleteOrder(int orderId)
        {
             ExecuteFaultHandledOperation(() =>
                {
                    IOrderRepository orderRepository = _DataRepositoryFactory.GetDataRepository<IOrderRepository>();

                    orderRepository.Remove(orderId);
                });
        }

        public Order[] GetOrdersForStacking(int commodityId, int orderTypeId, float variance)
        {
            return ExecuteFaultHandledOperation(() =>
                {
                    //Quite a lot of business logic to go in here to get the stack in the right order buy/sell
                    IOrderRepository orderRepository = _DataRepositoryFactory.GetDataRepository<IOrderRepository>();
                    ITradeRepository tradeRepository = _DataRepositoryFactory.GetDataRepository<ITradeRepository>();

                    //Better way to do this that getting all data... TODO
                    IEnumerable<Order> allOrdersAvailableForFilling = orderRepository.GetAllUnfilledOrders();
                    List<Order> orderStackBuy = new List<Order>();
                    List<Order> orderStackSell = new List<Order>();

                    foreach (Order order in allOrdersAvailableForFilling)
                    {
                        //Get some trade information from related fills, just as an exercise
                        var hasTrades = false;
                        //TODO
                        //Should we create a class of RowForStacker, that has all the info for the client view?
                        //In a business engine? 
                        //If the order has one leg, and it's a buy or a sell, put in particular one list or the other
                        //If the order is a carry, differentiate
                        if (order.IsBuy)
                            orderStackBuy.Add(order);
                        else
                            orderStackSell.Add(order);
                    }

                    return orderStackBuy.ToArray(); //TODO How do I return both arrays? Do i need a new Stack class?
                });
   
        }
 

     
    }
}
