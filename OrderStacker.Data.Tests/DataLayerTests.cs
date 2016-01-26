using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Core.Common.Contracts;
using Core.Common.Core;
using OrderStacker.Business.Entities;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using OrderStacker.Business.Bootstrapper;
using OrderStacker.Data.Contracts;
using OrderStacker.Data.Contracts.Repository_Interfaces;
using System.Runtime.Serialization;

namespace OrderStacker.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            //this will run before everything so we can set stuff up here
            //MEF discoverability - go out to assemblies and get the ones with [Export]
            //We will do that bit in the bootstrapper...
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();
            //IEnumerable<Order> orders = repositoryTest.GetOrders();
            
            //Assert.IsTrue(orders != null);
            IEnumerable<Account> accounts = repositoryTest.GetAccounts();
        }   

        [TestMethod]
        public void test_repository_factory_usage()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();
            IEnumerable<Account> accounts = factoryTest.GetAccounts();

            Assert.IsTrue(accounts != null);
        }

        [TestMethod]
        public void test_factory_mocking1()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account() { AccountId = 1, Description = "Test Account 1", ShortCode="TST1"},
                new Account() { AccountId = 2, Description = "Test Account 2", ShortCode="TST2"},
                new Account() { AccountId = 3, Description = "Test Account 3", ShortCode="TST3"}
            };

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IAccountRepository>().Get()).Returns(accounts); 
    
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);
            IEnumerable<Account> ret = factoryTest.GetAccounts();

            Assert.IsTrue(ret == accounts);
        }

        [TestMethod]
        public void test_factory_mocking2()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account() { AccountId = 1, Description = "Test Account 1", ShortCode="TST1"},
                new Account() { AccountId = 2, Description = "Test Account 2", ShortCode="TST2"},
                new Account() { AccountId = 3, Description = "Test Account 3", ShortCode="TST3"}
            };

            Mock<IAccountRepository> mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRepository.Setup(obj => obj.Get()).Returns(accounts);

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<IAccountRepository>()).Returns(mockAccountRepository.Object);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);
            IEnumerable<Account> ret = factoryTest.GetAccounts();

            Assert.IsTrue(ret == accounts);

        }

        [TestMethod]
        public void test_repository_mocking()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account() { AccountId = 1, Description = "Test Account 1", ShortCode="TST1"},
                new Account() { AccountId = 2, Description = "Test Account 2", ShortCode="TST2"}
            };

            Mock<IAccountRepository> mockAccountRepository = new Mock<IAccountRepository>();
            mockAccountRepository.Setup(obj => obj.Get()).Returns(accounts);

            RepositoryTestClass repositoryTest = new RepositoryTestClass(mockAccountRepository.Object);
            IEnumerable<Account> ret = repositoryTest.GetAccounts();

            Assert.IsTrue(ret == accounts);
        }

        
    }

    public class RepositoryTestClass
    {
        //dependency injection testing
        public RepositoryTestClass()
        {
            //Because this test class is not within the MEFLoader catalog building,
            //I have to explicitly tell this test class to try to resolve itself manually
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        //Give it a constructur, so I can pass it the repo I want it to use
        //Maybe the repo is the db, maybe it's a Moq'd repo
        //public RepositoryTestClass(IOrderRepository orderRepository)
        //{
        //    _OrderRepository = orderRepository;
        //}

        //[Import] //So MEF knows to resolve this
        //IOrderRepository _OrderRepository;

        public RepositoryTestClass(IAccountRepository accountRepository)
        {
            _AccountRepository = accountRepository;
        }

        [Import]
        IAccountRepository _AccountRepository;

        //Some method of useage
        //public IEnumerable<Order> GetOrders()
        //{
        //    IEnumerable<Order> orders = _OrderRepository.Get();
        //    return orders;
        //}
        public IEnumerable<Account> GetAccounts()
        {
            IEnumerable<Account> accounts = _AccountRepository.Get();
            return accounts;
        }
    }
    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        public IEnumerable<Account> GetAccounts()
        {
            IAccountRepository accountRepository = _DataRepositoryFactory.GetDataRepository<IAccountRepository>();

            IEnumerable<Account> accounts = accountRepository.Get();
            return accounts;
        }
    }
}
