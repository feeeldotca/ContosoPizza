
namespace ContosoPizza.Data;

public static class Extensions
{
    // the CreateDbIfNotExists method is defined as an extension of IHost.
    public static void CreateDbIfNotExists(this IHost host){
        using(var scope = host.Services.CreateScope()){
            var services = scope.ServiceProvider;
            // A reference to the PizzaContext service is created.
            var context = services.GetRequiredService<PizzaContext>();
            // EnsureCreated ensures the database exists. 
            // it creates a new database if one doesn't exist.
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
    
}
