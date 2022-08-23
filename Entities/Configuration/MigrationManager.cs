using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.Configuration {
    public static class MigrationManager {
        public static WebApplication MigrateDatabase(this WebApplication webApp) {
            using(var scope = webApp.Services.CreateScope()) {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>()) {
                    try {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex) {
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
