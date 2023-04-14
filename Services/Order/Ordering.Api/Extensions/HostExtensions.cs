using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Api.Extensions
{
    public static class HostExtensions
    {
        //public static IHost MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
        //{
        //    //int retryForAvailability = retry.Value;

        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var logger = services.GetRequiredService<ILogger<TContext>>();
        //        var context = services.GetService<TContext>();

        //        try
        //        {
        //            logger.LogInformation("migrating started for sql server");
        //            context.Database.Migrate();
        //            //seeder(context, services);
        //            logger.LogInformation("migrating has been done for sql server");
        //        }
        //        catch (SqlException e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }

        //    return host;
        //}
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            app.UseHsts();
            app.UseHttpsRedirection();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                var context = serviceScope?.ServiceProvider.GetRequiredService<OrderContext>();
                context?.Database.EnsureCreated();
            }
        }
    }
}
