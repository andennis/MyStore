using System;
using AutoMapper;
using Common.Repository;
using Microsoft.Practices.Unity;
using MyStore.BL;
using MyStore.BL.Services;
using MyStore.Core;
using MyStore.Core.Services;
using MyStore.Repository;

namespace MyStore.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            MapperConfiguration cfg = AutoMapperConfig.Configure();
            container.RegisterInstance(typeof(IMapper), cfg.CreateMapper(), new ContainerControlledLifetimeManager());
            container.RegisterType<IDbConfig, MyStoreConfig>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMyStoreConfig, MyStoreConfig>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMyStoreUnitOfWork, MyStoreUnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IUserService, UserService>(new PerRequestLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new PerRequestLifetimeManager());
            container.RegisterType<IClientService, ClientService>(new PerRequestLifetimeManager());
            container.RegisterType<IOrderService, OrderService>(new PerRequestLifetimeManager());
        }
    }
}
