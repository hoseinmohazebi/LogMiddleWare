using LogMiddleWare.Data;
using Microsoft.EntityFrameworkCore;

namespace LogMiddleWare.Configuration.Middleware.Migration
{
    public static class ApplyPendingMigration
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope?.ServiceProvider?.GetService<ApplicationDbContext>()?.Database.Migrate();
            }
        }

    }
}
