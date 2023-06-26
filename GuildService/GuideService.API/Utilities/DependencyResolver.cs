using Autofac;
using GuideService.Data.Repositories;
using GuideService.Data.Services;

namespace GuideService.API.Utilities
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadRepositories(builder);
        }
        private void LoadRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<PersonRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void LoadServices(ContainerBuilder builder)
        {
            builder.RegisterType<DataServices>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
