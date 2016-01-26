using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OrderStacker.Business.Entities;
using Core.Common.Core;
using Core.Common.Contracts;
using System.Runtime.Serialization;

namespace OrderStacker.Data
{
    public class OrderStackerContext : DbContext
    {
        public OrderStackerContext()
            : base("name=OrderStacker")
        {
            //Initialisation Strategy 

           // Database.SetInitializer<OrderStackerContext>(null);
            Database.SetInitializer(new MyInitializer());
        }

        public class MyInitializer : DropCreateDatabaseAlways<OrderStackerContext>
        {

            protected override void Seed(OrderStackerContext context)
            {
                // seed database here
                IList<Account> defaultAccountSet = new List<Account>();

                defaultAccountSet.Add(new Account() { Description = "Test Account 1", ShortCode = "TST1", DateCreated = DateTime.Now , DateModified = DateTime.Now });
                defaultAccountSet.Add(new Account() { Description = "Test Account 2", ShortCode = "TST2", DateCreated = DateTime.Now , DateModified = DateTime.Now });
                defaultAccountSet.Add(new Account() { Description = "Test Account 3", ShortCode = "TST3", DateCreated = DateTime.Now, DateModified = DateTime.Now });

                foreach (Account acc in defaultAccountSet)
                    context.AccountSet.Add(acc);

                IList<User> defaultUserSet = new List<User>();
                defaultUserSet.Add(new User(){ UserId = 1, AccountId = 1, LoginEmail = "graemerenfrew@gmail.com", FirstName = "Graeme", LastName  = "Renfrew", Address = "1 Big Street",City = "London",    State = "NA",   ZipCode = "E2 7SG", DateCreated = DateTime.Now , DateModified = DateTime.Now});
                defaultUserSet.Add(new User() { UserId = 2, AccountId = 2, LoginEmail = "graemerenfrew@gmail.com", FirstName = "Gordon", LastName = "Jackson", Address = "2 Big Street", City = "London", State = "NA", ZipCode = "E2 7SG", DateCreated = DateTime.Now , DateModified = DateTime.Now });
                defaultUserSet.Add(new User() { UserId = 3, AccountId = 3, LoginEmail = "graemerenfrew@gmail.com", FirstName = "Lewis", LastName = "Collins", Address = "3 Big Street", City = "London", State = "NA", ZipCode = "E2 7SG",  DateCreated = DateTime.Now , DateModified = DateTime.Now });
                defaultUserSet.Add(new User() { UserId = 4, AccountId = 3, LoginEmail = "graemerenfrew@gmail.com", FirstName = "David", LastName = "Starsky", Address = "4 Big Street", City = "London", State = "NA", ZipCode = "E2 7SG", DateCreated = DateTime.Now , DateModified = DateTime.Now });

                foreach (User u in defaultUserSet)
                    context.UserSet.Add(u);

                IList<Market> defaultMarketSet = new List<Market>();
                defaultMarketSet.Add(new Market() { MarketId = 1, Description = "London Metal Exchange", ShortCode = "LME" });
                defaultMarketSet.Add(new Market() { MarketId = 2, Description = "Chicago Mercantile Exchange", ShortCode = "CME" });

                foreach (Market m in defaultMarketSet)
                    context.MarketSet.Add(m);

                IList<Commodity> defaultCommoditySet = new List<Commodity>();
                defaultCommoditySet.Add(new Commodity() { CommodityId = 1, Description = "LME Copper", MarketId = 1, ShortCode="CA"});
                defaultCommoditySet.Add(new Commodity() { CommodityId = 2, Description = "LME Aluminum", MarketId = 1, ShortCode = "AH" });
                defaultCommoditySet.Add(new Commodity() { CommodityId = 3, Description = "LME Lead", MarketId = 1, ShortCode = "PB" });
                defaultCommoditySet.Add(new Commodity() { CommodityId = 4, Description = "LME Tin", MarketId = 1, ShortCode = "SB" });
                defaultCommoditySet.Add(new Commodity() { CommodityId = 5, Description = "LME Naasac", MarketId = 1, ShortCode = "NA" });
                defaultCommoditySet.Add(new Commodity() { CommodityId = 6, Description = "LME Zinc", MarketId = 1, ShortCode = "ZN" });
                defaultCommoditySet.Add(new Commodity() { CommodityId = 7, Description = "LME Nickel", MarketId = 1, ShortCode = "NI" });
                defaultCommoditySet.Add(new Commodity() { CommodityId = 8, Description = "LME Aluminium Alloy", MarketId = 1, ShortCode = "AA" });

                foreach (Commodity com in defaultCommoditySet)
                    context.CommoditySet.Add(com);


                //Add reference data
                IList<OrderStatus> defaultOrderStatusSet = new List<OrderStatus>();
                defaultOrderStatusSet.Add(new OrderStatus() { OrderStatusId = 1, Code = "UNFILLED", Description = "Entire quantity of the order remains unfilled." });
                defaultOrderStatusSet.Add(new OrderStatus() { OrderStatusId = 2, Code = "FILLED", Description = "Entire quantity of the order has been filled." });
                defaultOrderStatusSet.Add(new OrderStatus() { OrderStatusId = 3, Code = "PARTIAL", Description = "Partial quantity of the order has been filled." });
                defaultOrderStatusSet.Add(new OrderStatus() { OrderStatusId = 4, Code = "CANCELLED", Description = "Order has been cancelled." });
                defaultOrderStatusSet.Add(new OrderStatus() { OrderStatusId = 5, Code = "PARTIALCANCEL", Description = "Order was partially filled, then cancelled." });
                foreach (OrderStatus ord in defaultOrderStatusSet)
                    context.OrderStatusSet.Add(ord);

                IList<OrderType> defaultOrderTypeSet = new List<OrderType>();
                defaultOrderTypeSet.Add(new OrderType() { OrderTypeId = 1, Code = "OUTRIGHT", Description = "This order was booked as a trade." });
                defaultOrderTypeSet.Add(new OrderType() { OrderTypeId = 2, Code = "LIMIT", Description = "This order was booked as a limit order." });
                defaultOrderTypeSet.Add(new OrderType() { OrderTypeId = 3, Code = "TIMED", Description = "This order was booked as a timed order." });
                defaultOrderTypeSet.Add(new OrderType() { OrderTypeId = 4, Code = "CARRY", Description = "This order was booked as a carry." });

                foreach (OrderType ord in defaultOrderTypeSet)
                    context.OrderTypeSet.Add(ord);

                //Orders, both filled (so we can have TRADES) and unfilled
                IList<Order> defaultOrderSet = new List<Order>();
                defaultOrderSet.Add(
                        new Order()
                        {
                            OrderId = 1, 
                            AccountId = 1,
                            IsBuy = true,
                            CommodityId = 1, 
                            EnteredByUserId = 1,
                            OrderStatusId = 1,
                            OrderTypeId = 2,
                            DateCreated = DateTime.Now , DateModified = DateTime.Now ,
                            OrderHeaders = new List<OrderHeader>
                            {
                                new OrderHeader() { OrderHeaderId = 1, 
                                                    Active = true, 
                                                    TotalQuantity = 100, 
                                                    ValidUntilTime = DateTime.Now,
                                                    DateCreated = DateTime.Now , DateModified = DateTime.Now ,
                                                    OrderLegs = new List<OrderLeg>
                                                    {
                                                        new OrderLeg() { OrderLegId = 1, IsBuy = true, CurrencyISOCode = "USD", BaseLimit=10000, Limit=10000, PromptDate= new DateTime(2015, 11,1), Quantity= 50, Rate = 1, StopLoss = 0, DateCreated = DateTime.Now , DateModified = DateTime.Now },
                                                        new OrderLeg() { OrderLegId = 2, IsBuy = true, CurrencyISOCode = "USD", BaseLimit=10000, Limit=10000, PromptDate= new DateTime(2015, 12,1), Quantity= 50, Rate = 1, StopLoss = 0, DateCreated = DateTime.Now , DateModified = DateTime.Now },
                                                    }
                                                   }
                            }
                        }

                    );
                defaultOrderSet.Add(

                             new Order()
                             {
                                 OrderId = 2,
                                 AccountId = 2,
                                 IsBuy = false,
                                 CommodityId = 1,
                                 EnteredByUserId = 2,
                                 OrderStatusId = 1,
                                 OrderTypeId = 2,
                                 DateCreated = DateTime.Now , DateModified = DateTime.Now ,
                                 OrderHeaders = new List<OrderHeader>
                            {
                                new OrderHeader() { OrderHeaderId = 2, 
                                                    Active = true, 
                                                    TotalQuantity = 10, 
                                                    ValidUntilTime = DateTime.Now,
                                                    DateCreated = DateTime.Now , DateModified = DateTime.Now ,
                                                    OrderLegs = new List<OrderLeg>
                                                    {
                                                        new OrderLeg() { OrderLegId = 3, IsBuy = false, CurrencyISOCode = "USD", BaseLimit=9000, Limit=9000, PromptDate= new DateTime(2015, 10,1), Quantity= 5, Rate = 1, StopLoss = 0, DateCreated = DateTime.Now , DateModified = DateTime.Now },
                                                        new OrderLeg() { OrderLegId = 4, IsBuy = false, CurrencyISOCode = "USD", BaseLimit=9000, Limit=9000, PromptDate= new DateTime(2015, 10,11), Quantity= 5, Rate = 1, StopLoss = 0, DateCreated = DateTime.Now , DateModified = DateTime.Now },
                                                    }
                                                   }
                            }
                             }
                    );

                defaultOrderSet.Add(

                             new Order()
                             {
                                 OrderId = 3,
                                 AccountId = 3,
                                 IsBuy = false,
                                 CommodityId = 1,
                                 EnteredByUserId = 4,
                                 OrderStatusId = 2, //filled
                                 OrderTypeId = 1, //Outright
                                 DateCreated = DateTime.Now , DateModified = DateTime.Now,
                                 OrderHeaders = new List<OrderHeader>
                            {
                                new OrderHeader() { OrderHeaderId = 3, 
                                                    Active = true, 
                                                    TotalQuantity = 5, 
                                                    ValidUntilTime = DateTime.Now,
                                                    DateCreated = DateTime.Now , DateModified = DateTime.Now ,
                                                    OrderLegs = new List<OrderLeg>
                                                    {
                                                        new OrderLeg() { OrderLegId = 4, IsBuy = false, CurrencyISOCode = "USD", BaseLimit=4444, Limit=4444, PromptDate= new DateTime(2015, 08,17), Quantity= 5, Rate = 1, StopLoss = 0, DateCreated = DateTime.Now , DateModified = DateTime.Now },
                                                    }
                                                   }
                            }
                             }
                    );

                foreach (Order ord in defaultOrderSet)
                    context.OrderSet.Add(ord);

                IList<Trade> defaultTradeSet = new List<Trade>();
                defaultTradeSet.Add(new Trade() { TradeId = 1, OrderHeaderId = 3, OrderId = 3, AccountId = 3, FilledByUserId = 2, OrderLegId = 4, Price = 4444, Quantity = 5, FXRate = 1, DateCreated = DateTime.Now, DateModified = DateTime.Now });

                foreach (Trade fill in defaultTradeSet)
                    context.TradeSet.Add(fill);

                base.Seed(context);
            }
        }

        public DbSet<Account> AccountSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<Market> MarketSet { get; set; }
        public DbSet<Trade> TradeSet { get; set; }
        public DbSet<Commodity> CommoditySet { get; set; }
        public DbSet<Order> OrderSet { get; set; }
        public DbSet<OrderLeg> OrderLegSet { get; set; }
        public DbSet<OrderHeader> OrderHeaderSet { get; set; }

        public DbSet<OrderStatus> OrderStatusSet { get; set; }
        public DbSet<OrderType> OrderTypeSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //ignore some fields if need-be
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            //mapping rules
            //Which column in the table/entities are the ID field?
            //Keeps everything in one place
            modelBuilder.Entity<Account>().HasKey<int>(e => e.AccountId).Ignore(e=>e.EntityId);
            modelBuilder.Entity<User>().HasKey<int>(e => e.UserId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Market>().HasKey<int>(e => e.MarketId);
            modelBuilder.Entity<Trade>().HasKey<int>(e => e.TradeId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Order>().HasKey<int>(e => e.OrderId).Ignore(e => e.EntityId);
            modelBuilder.Entity<OrderLeg>().HasKey<int>(e => e.OrderLegId).Ignore(e => e.EntityId);
            modelBuilder.Entity<OrderHeader>().HasKey<int>(e => e.OrderHeaderId).Ignore(e => e.EntityId);
            modelBuilder.Entity<OrderStatus>().HasKey<int>(e => e.OrderStatusId).Ignore(e => e.EntityId);
            modelBuilder.Entity<OrderType>().HasKey<int>(e => e.OrderTypeId).Ignore(e => e.EntityId);
        
            //We would also perhaps like to ignore any 'calculated' values we apply to entities, that don't exist in the table
            //for example 'InTheMoney' or something like that, so we put the IgnoreEntityFieldDontAddToTable .Ignore in here
        }

        public override int SaveChanges()  //Allow us to always store the created/changed time
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is EntityBase && (e.State == EntityState.Added ||
                    e.State == EntityState.Modified))
                    .Select(e => e.Entity as EntityBase)
                )
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }


            int result = base.SaveChanges();  //How would we do this?  Do we want to save entities then undirty them?
            //foreach (var history in this.ChangeTracker.Entries()
            //    .Where(e => e.Entity is EntityBase)
            //    .Select(e => e.Entity as EntityBase)
            //    )
            //{
            //    history.IsDirty = false;
            //}
            return result;
        }
    }
}
