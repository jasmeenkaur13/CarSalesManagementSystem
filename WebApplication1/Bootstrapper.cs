using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer;
using DataModels.UnitOfWork;
using Microsoft.Practices.Unity;
using Unity.Mvc3;


namespace WebApplication1
{
        public static class Bootstrapper
        {
            public static void Initialise()
            {
                var container = BuildUnityContainer();

                DependencyResolver.SetResolver(new UnityDependencyResolver(container));

                // register dependency resolver for WebAPI RC
                GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            }

            private static IUnityContainer BuildUnityContainer()
            {
                var container = new UnityContainer();

                // register all your components with the container here
                // it is NOT necessary to register your controllers

                container.RegisterType<IAdvertiseCarDetailsService, AdvertisedCarDetailService>();
                container.RegisterType<IOwnerService, OwnerService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
                container.RegisterType<IAdvertiseCarService, AdvertisedCarService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
                container.RegisterType<ICarOwnerReferenceService,CarOwnerReferenceService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

                return container;
            }
        }
    }