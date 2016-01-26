using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using Core.Common.Contracts;
using System.Runtime.Serialization;

namespace OrderStacker.Business.Entities
{
    [DataContract]
    public class OrderStatus : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int OrderStatusId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        #region IIdentifiableEntity members

        public int EntityId
        {
            get { return OrderStatusId; }
            set { OrderStatusId = value; }
        }

        #endregion
    }

    [DataContract]
    public class OrderType: EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int OrderTypeId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int EntityId
        {
            get { return OrderTypeId; }
            set { OrderTypeId = value; }
        }

    }
}
