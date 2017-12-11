using GraphQLServer.Core.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Api.Extension
{
    public static class IWebHostExtenstion
    {
        public static IWebHost Migrate(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<DocumentContext>())
                {
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }
            }
            return webhost;
        }
    }
}
