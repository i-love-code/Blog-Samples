using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System.Web.Mvc;
using System.Web.Routing;

namespace CommerceSite.Web.Business
{
    [InitializableModule]
    public class SiteInitializer : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            InitializeDependencyInjection();

            InitializeRouting(RouteTable.Routes);
        }

        private void InitializeDependencyInjection()
        {
            DependencyResolver.SetResolver(ServiceLocator.Current);
        }

        private void InitializeRouting(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
        }

        public void Uninitialize(InitializationEngine context)
        {
            
        }
    }
}