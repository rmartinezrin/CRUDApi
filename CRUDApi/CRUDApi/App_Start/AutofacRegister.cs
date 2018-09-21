using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using CRUDApi.Application;
using CRUDApi.Application.Contracts;
using CRUDApi.Application.Services;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace CRUDApi
{
    internal class AutofacRegister
    {     

        internal static void Register()
        {
            ContainerBuilder builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            
            builder.RegisterType<UserManagementService>().As<IUserManagementService>().InstancePerRequest();
           
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AplicationModule());
            IContainer container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container); 
        }        
    }
}