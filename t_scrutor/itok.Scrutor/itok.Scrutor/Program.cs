using Microsoft.Extensions.DependencyInjection;

var sc = new ServiceCollection();

#region Scan 


sc.Scan(scan => scan
    .FromAssemblyOf<Program>() // scan entry point
        // We filter out only the classes that are assignable to ITransientService.
        .AddClasses(classes => classes.AssignableTo<IAsTransient>())
            // We then specify what type we want to register these classes as.
            // In this case, we want to register the types as all of its implemented interfaces.
            // So if a type implements 3 interfaces; A, B, C, we'd end up with three separate registrations.
            .AsImplementedInterfaces()
            // Lifetime
            .WithTransientLifetime()
        // Here we start again, with a new full set of classes from the assembly above.
        // This time, filtering out only the classes assignable to IScopedService.
        .AddClasses(classes => classes.AssignableTo<IAsScoped>())
            // Now, we just want to register these types as a single interface, IScopedService.
            .As<IAsScoped>()
            // And again, just specify the lifetime.
            .WithScopedLifetime()
        // Generic interfaces are also supported too, e.g. public interface IOpenGeneric<T> 
        .AddClasses(classes => classes.AssignableTo(typeof(IOpenGeneric<>)))
            .AsImplementedInterfaces()
        // And you scan generics with multiple type parameters too
        // e.g. public interface IQueryHandler<TQuery, TResult>
        .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces());


#endregion

#region Decorate
//This method is used to decorate already registered services.

#endregion
