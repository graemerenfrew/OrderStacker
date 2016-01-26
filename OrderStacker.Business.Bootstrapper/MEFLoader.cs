using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using OrderStacker.Data.Data_Repositories;
using OrderStacker.Business.Business_Engines;
//using Core.Common.Contracts;
//using Core.Common;
//using OrderStacker.Data.Contracts;
using OrderStacker.Business.Common;

namespace OrderStacker.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            //Add items to the MEF catalog here - tell MEF to go out and scan for assemblies
            //that I might want to use for dependency injection
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AccountRepository).Assembly));
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(OrderRepository).Assembly));
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(UserRepository).Assembly));

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(OrderStackerEngine).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
