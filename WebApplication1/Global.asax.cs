using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // 1. Create a new Simple Injector container
            var container = new Container();

            // a.1 webapi, frist register controller
            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver()
                .GetControllerTypes(services.GetAssembliesResolver());

            // register Web API controllers (important! http://bit.ly/1aMbBW0)
            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }


            // 2. Configure the container (register)
            //container.Register<IUserService, UserService>(Lifestyle.Transient);
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);
            container.Register<Iaaa, aaa>(Lifestyle.Transient);

            container.RegisterInitializer<tstController>(c => c.s2 = new bbb());

            // See below for more configuration examples

            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Store the container for use by Page classes.
            //WebApiApplication.Container = container;
            System.Web.Mvc.DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            // a.2 webapi
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // 5. register global filters
            //RegisterGlobalFilters(GlobalFilters.Filters, container);
        }

        //public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        //{
        //}
    }
}
