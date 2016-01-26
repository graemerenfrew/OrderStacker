using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Core.Common.Core;
using Core.Common.Contracts;

namespace OrderStacker.Business.Entities
{
    [DataContract]
    public class Order : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public bool IsBuy { get; set; }

        [DataMember]
        public int EnteredByUserId { get; set; }

        [DataMember]
        public int CommodityId { get; set; }

        [DataMember]
        public int OrderTypeId { get; set; }

        [DataMember]
        public int OrderStatusId { get; set; }


        [DataMember]
        public List<OrderHeader> OrderHeaders { get; set; }

        public int EntityId
        {
            get
            {
                return OrderId;
            }
            set
            {
                OrderId = value;
            }
        }

        int IAccountOwnedEntity.OwnerAccountId
        {
            get { return AccountId; }
        }

    }

    [DataContract]
    public class OrderHeader : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int OrderHeaderId { get; set; }

        [DataMember]
        public int TotalQuantity { get; set; }

        [DataMember]
        public DateTime ValidUntilTime { get; set; }

        [DataMember]
        public bool Active { get; set; }


        [DataMember]
        public List<OrderLeg> OrderLegs { get; set; }

        public int EntityId
        {
            get
            {
                return OrderHeaderId;
            }
            set
            {
                OrderHeaderId = value;
            }
        }
    }

    [DataContract]
    public class OrderLeg : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int OrderLegId { get; set; }

        [DataMember]
        public bool IsBuy { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public DateTime PromptDate { get; set; }

        [DataMember]
        public float Limit { get; set; }

        [DataMember]
        public float StopLoss { get; set; }

        [DataMember]
        public string CurrencyISOCode { get; set; }

        [DataMember]
        public float Rate { get; set; }
         
        [DataMember]
        public float BaseLimit { get; set; }


        public int EntityId
        {
            get
            {
                return OrderLegId;
            }
            set
            {
                OrderLegId = value;
            }
        }
    }
}
