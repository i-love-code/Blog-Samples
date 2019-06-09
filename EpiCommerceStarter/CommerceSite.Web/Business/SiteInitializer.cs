using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CommerceSite.Web.Business
{
    [InitializableModule]
    public class SiteInitializer : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            InitializeRouting();

            InitializeDependencyInjection();
        }

        private void InitializeDependencyInjection()
        {
            DependencyResolver.SetResolver(ServiceLocator.Current);
        }

        private void InitializeRouting()
        {
            var routes = RouteTable.Routes;

            routes.MapRoute("DefaultMvc", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "" });
        }

        public void Uninitialize(InitializationEngine context)
        {
            
        }
    }
}