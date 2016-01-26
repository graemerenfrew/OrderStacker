using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace OrderStacker.Business.Entities
{

    public class Market
    {
        [DataMember]
        public int MarketId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ShortCode { get; set; }
    }
}
