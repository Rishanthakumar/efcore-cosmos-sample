
using EFCoreCosmosSample.Core.Interfaces.Repositories;
using EFCoreCosmosSample.Infrastructure.Contexts;
using EFCoreCosmosSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreCosmosSample.Infrastructure.Extentions
{
    public static class DependencyInjection
    {
		public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FamilyContext>(options =>
				options.UseCosmos(
					configuration["Cosmos:AccountEndpoint"],
					configuration["Cosmos:AccountKey"],
					configuration["Cosmos:DatabaseName"])
			);
			services
				.AddScoped<IFamilyRepository, FamilyRepository>();
		}
	}
}
