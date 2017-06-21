using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Trainings.Infrastructure.Mappers;

namespace Trainings.Infrastructure.IoC.Modules
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration Configuration;

        public ContainerModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule(new SettingsModule(Configuration));
        }
    }
}
