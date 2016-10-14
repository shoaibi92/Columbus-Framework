
//using Microsoft.Practices.Unity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
//using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
//using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord;
//using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
//using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
//using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
//using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
//using Sage.CA.SBS.ERP.Sage300.Common.Models;
//using System;
//using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Service.Mock;

//namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity
//{
//    /// <summary>
//    /// Test Class for BaseRepository TestFixture
//    /// </summary>
//    [TestClass]
//    public class BaseRepositoryTestFixture : BaseTestFixture
//    {
//        /// <summary>
//        /// The context
//        /// </summary>
//        protected Context Context;

//        /// <summary>
//        /// Baserepositorytestfixture class constructor
//        /// </summary>
//        public BaseRepositoryTestFixture()
//        {
//            Context = CreateContext();
//            Register();
//        }

//        /// <summary>
//        /// To create context for mock classes
//        /// </summary>
//        /// <returns>Context</returns>
//        protected Context CreateContext()
//        {
//            return new Context
//            {
//                SessionId = "dmpg2qrxq2zvuequ22jtmyh2",
//                ContextToken = Guid.NewGuid(),
//                Container = new SageUnityContainer(),
//                ScreenContext = new ScreenContext(),
//                Company = "SAMLTD",
//                ApplicationUserId = "ADMIN"
//            };
//        }
//        /// <summary>
//        /// Methods that mocks business entity (PseudoBusinessEntity)
//        /// </summary>
//        /// <param name="view">The view that has to be opened during mocking</param>
//        /// <returns>Mocked business entity object</returns>
//        protected IBusinessEntity MockEntity(string view)
//        {
//            var mock = new Mock<IBusinessEntity>();
//            var pseudoEntitySession = new PseudoBusinessEntitySession();
//            var pseudoBusinessEntity = new PseudoBusinessEntity(pseudoEntitySession, view);
//            mock.Setup(obj => obj.Session).Returns(pseudoBusinessEntity.Session);
//            return mock.Object;
//        }
//        /// <summary>
//        /// Registers this instance.
//        /// </summary>
//        protected void Register()
//        {
//            RegisterType<IBusinessEntity, BusinessEntity>(Context.Container);
//            RegisterType<ICommonRepository, CommonRepository>(Context.Container);
//        }

//        /// <summary>
//        /// Register Type based on Constructor Name
//        /// </summary>
//        /// <typeparam name="TFrom">TFrom</typeparam>
//        /// <typeparam name="TTo">TTo</typeparam>
//        /// <param name="container">Container</param>
//        /// <param name="name">ConstructorName</param>
//        /// <param name="injectionMember">Injection Constructor Members</param>
//        protected static void RegisterType<TFrom, TTo>(IUnityContainer container, string name,
//            params InjectionMember[] injectionMember) where TTo : TFrom
//        {
//            if (!container.IsRegistered<TFrom>(name))
//            {
//                container.RegisterType<TFrom, TTo>(name, injectionMember);
//            }
//        }

//        /// <summary>
//        /// Register type if not already registered
//        /// </summary>
//        /// <param name="container">IUnityContainer</param>
//        /// <param name="from">Type to convert from</param>
//        /// <param name="to">Type to convert to</param>
//        /// <param name="name">The name.</param>
//        /// <param name="injectionMember">The injection member.</param>
//        protected static void RegisterType(IUnityContainer container, Type from, Type to, string name,
//            params InjectionMember[] injectionMember)
//        {
//            if (!container.IsRegistered(from))
//            {
//                container.RegisterType(from, to, name, injectionMember);
//            }
//        }

//        /// <summary>
//        /// Register type if not already registered
//        /// </summary>
//        /// <typeparam name="TFrom">TFrom</typeparam>
//        /// <typeparam name="TTo">TTo</typeparam>
//        /// <param name="container">IUnityContainer</param>
//        protected static void RegisterType<TFrom, TTo>(IUnityContainer container) where TTo : TFrom
//        {
//            if (!container.IsRegistered<TFrom>())
//            {
//                container.RegisterType<TFrom, TTo>();
//            }
//        }

//        /// <summary>
//        /// Methods that mocks entity session
//        /// </summary>
//        /// <param name="view">The view that has to be opened during mocking</param>
//        /// <returns>Mocked business session object</returns>
//        protected IBusinessEntitySession MockEntitySession(string view)
//        {
//            var mock = new Mock<IBusinessEntitySession>();
//            var pseudoEntitySession = new PseudoBusinessEntitySession();
//            mock.Setup(obj => obj.OpenView(It.IsAny<string>(), It.IsAny<IBusinessEntitySession>()))
//                .Returns(pseudoEntitySession.OpenView(view, pseudoEntitySession));
//            return mock.Object;
//        }

//        /// <summary>
//        /// The Account Set data
//        /// </summary>
//        private CommonServiceRepository _commonServiceData;

//        /// <summary>
//        /// property Mock data access for Account Set
//        /// </summary>
//        /// <value>The Account Set data.</value>
//        protected CommonServiceRepository CommonServiceData
//        {
//            get
//            {
//                if (_commonServiceData == null)
//                {
//                      _commonServiceData = new CommonServiceRepository(Context);
//                }
              
//                    return _commonServiceData;
                
               
//            }
//        }


//        /// <summary>
//        /// Test Type
//        /// </summary>
//        public enum TestType
//        {
//            /// <summary>
//            /// The mock
//            /// </summary>
//            Mock,

//            /// <summary>
//            /// The database
//            /// </summary>
//            Database
//        }
//    }
//}
