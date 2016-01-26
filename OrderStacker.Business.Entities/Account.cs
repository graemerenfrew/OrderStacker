using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace OrderStacker.Business.Entities
{
    [DataContract]
    public class Account : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ShortCode { get; set; }

        public int EntityId
        {
            get
            {
                return AccountId;
            }
            set
            {
                AccountId = value;
            }
        }
    }
}
