using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using System.Runtime.Serialization;
using Core.Common.Core;

namespace OrderStacker.Business.Entities
{
    [DataContract]
    public class Trade : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember ]
        public int TradeId {get; set;}
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int OrderHeaderId { get; set; }
        [DataMember]
        public int OrderLegId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public float FXRate { get; set; }
        [DataMember]
        public int FilledByUserId { get; set; }

        [DataMember]
        public int AccountId { get; set; }



        public int EntityId
        {
            get
            {
                return TradeId;
            }
            set
            {
                TradeId = value;
            }
        }

        public int OwnerAccountId
        {
            get { return AccountId; }
        }
    }
}
