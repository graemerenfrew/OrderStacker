using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStacker.Business.Entities;

namespace OrderStacker.Data.Contracts//.DTOs
{
    public class UserOrderInfo
    {  //We can then use this UserOrderInfo entity in a link to entity query in one of our repositories
        public Order Order { get; set; }
        public User User { get; set; }
        public Account Account { get; set; }

    }
}
