using Autofac;
using CSharp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.CrossCutting.Ioc
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
               .AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
