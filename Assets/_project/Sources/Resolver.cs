using _project.Sources.Puzzle.Infrastructure;
using Autofac;

namespace _project.Sources
{
    public class Resolver
    {
        public static readonly Resolver Instance = new Resolver();
        private readonly IContainer _container;

        private Resolver()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<AutofacModule>();

            _container = containerBuilder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}