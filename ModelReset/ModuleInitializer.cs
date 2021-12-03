using Catel.IoC;
using ModelReset.Contracts;
using ModelReset.DAL;

/// <summary>
/// Used by the ModuleInit. All code inside the InitializeResourceGroups method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        // Code added here will be executed as soon as the assembly is loaded by the .net runtime. This
        // is a great opportunity to register any services in the service locator:

        var serviceLocator = ServiceLocator.Default;

        serviceLocator.RegisterType<ApplicationContext, ApplicationContext>();
        serviceLocator.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>(RegistrationType.Transient);

        var applicationContext = serviceLocator.ResolveType<ApplicationContext>();
        applicationContext.Database.EnsureCreated();
    }
}