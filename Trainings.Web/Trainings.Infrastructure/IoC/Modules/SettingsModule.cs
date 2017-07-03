using Autofac;
using Microsoft.Extensions.Configuration;
using Trainings.Infrastructure.Extentions;
using Trainings.Infrastructure.Settings;

namespace Trainings.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration Configuration;

        public SettingsModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(Configuration.GetSettings<GeneralSettings>())
                .SingleInstance();

            builder.RegisterInstance(Configuration.GetSettings<JWTSettings>())
                .SingleInstance();
        }
    }
}
