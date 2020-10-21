using _project.Sources.Puzzle.Domain;
using Autofac;

namespace _project.Sources.Puzzle.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ExampleService>().As<IExampleService>().SingleInstance();
        }
    }
}