using Autofac;
using CRUDApi.Application.Contracts;
using CRUDApi.Domain.Repositories.Contracts;
using CRUDApi.Domain.Repositories.Contracts.Users;
using CRUDApi.Domain.Services;
using CRUDApi.Infrastructure;
using CRUDApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Application
{
    public class AplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserDataContext>().As<IDataContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<UserDataContext>().As<IDataContext>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();            

            base.Load(builder);
        }
    }
}
