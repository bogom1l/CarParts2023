namespace CarParts.Web.Extensions
{
    using System.Reflection;

    public static class ExtensionMethodsForServices
    {
        public static IServiceCollection RegisterServiceReflection(this IServiceCollection serviceCollection,
            Type serviceType)
        {
            var assembly = Assembly.GetAssembly(serviceType);

            var types = assembly.GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract)
                .Where(t => t.Name.ToLower().EndsWith("service"))
                .ToList();

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().First(i => i.Name == $"I{type.Name}");
                serviceCollection.AddScoped(interfaceType, type);
            }

            return serviceCollection;
        }
    }
}