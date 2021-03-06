﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using MspecTest.Email;
using MspecTest.Repositories;
using MspecTest.Services;

namespace MspecTest {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        private IContainer Container;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Registration", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterIoC();
        }

        private void RegisterIoC() {
            var builder = new ContainerBuilder();
                    
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InjectActionInvoker();
            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();

            builder.RegisterType<RegistrationService>().As<IRegistrationService>();
            builder.Register(c => new SessionUserRepository(new HttpSessionStateWrapper(HttpContext.Current.Session))).As<IUserRepository>();
            builder.RegisterType<EmailSender>().As<IEmailSender>();

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}